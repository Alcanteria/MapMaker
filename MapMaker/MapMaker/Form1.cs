using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapMaker
{
    public partial class mainForm : Form
    {
        /********************************************SCREEN DIMENSIONS*/

            // Get the dimensions of the primary monitor.
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // The scale you want to draw the main window size to.
            private const float SCREEN_SCALE = .90f;

            // The size of the drawing surface as a percentage of the main window's size.
            private const float DRAWING_SURFACE_SCALE = .85f;

        /***********************************************MAP PARTS*/

            // Map object.
            private Map map = new Map(10, 10);

        /********************************************WINDOWS FORM PARTS*/

            // Declare a version of the picture box to use to draw on to.
            private PictureBox drawSurface;

            // Declare versions of buttons to interact with.
            private Button FLOOR_BUTTON;
            private Button DECOR_BUTTON;

            // Dialog box for selecting image files.
            OpenFileDialog selectImageDialog = new OpenFileDialog();

            // Dialog box for saving files.
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Pen for drawing the grid.
            Pen rectPen = new Pen(Color.Black);

        /*********************************************MOUSE CLICKS*/

            // This is an offest that compensates for a slight variance in click position.
            private const int X_OFFSET = 10;
            private const int Y_OFFSET = 33;

            // Location of the current mouse click on the map, filtered through any necessary offsets.
            private Point mouseLocation = new Point();

        public mainForm()
        {
            InitializeComponent();

            // Set up the key press listener.
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);

            // Link our draw surface to the picture box on the windows form.
            drawSurface = pictureBox;

            // Add the key listeners to the buttons on the form. This is to filter out arrow key presses when a button is selected.
            floorButton.PreviewKeyDown += new PreviewKeyDownEventHandler(floorButton_PreviewKeyDown);
            decorButton.PreviewKeyDown += new PreviewKeyDownEventHandler(decorButton_PreviewKeyDown);

            // Link our buttons to the form buttons
            FLOOR_BUTTON = floorButton;
            DECOR_BUTTON = decorButton;

            // Adjust the size of the main window based on the scale we've set above.
            this.Width  = (int)(screenWidth * SCREEN_SCALE);
            this.Height = (int)(screenHeight * SCREEN_SCALE);

            // Set the size of the drawing surface based on the main window's properties.
            drawSurface.Size = new Size((int)(Width * DRAWING_SURFACE_SCALE), (int)(Height * DRAWING_SURFACE_SCALE));
          
            // Open image dialog box properties
            selectImageDialog.Filter = "Image Files (*.bmp, *.gif, *.jpg, *.png)|*.bmp; *.gif; *.jpg; *.png";
            selectImageDialog.Multiselect = false;

            // Save file dialog box properties.
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog.RestoreDirectory = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the starting location of the main window.
            this.Location = new Point((int)(screenWidth * .05f), (int)(screenHeight * .05f));

            // Set the location of the buttons.
            FLOOR_BUTTON.Location = new Point(20, 50);
            DECOR_BUTTON.Location = new Point(FLOOR_BUTTON.Location.X, FLOOR_BUTTON.Location.Y + (FLOOR_BUTTON.Height + 5));

            // Set the starting location of the drawing space. This is based off of the location of the buttons.
            drawSurface.Location = new Point(FLOOR_BUTTON.Location.X + (FLOOR_BUTTON.Width + 5), FLOOR_BUTTON.Location.Y);            

            // Link the paint event of our draw surface to the windows event cycle
            drawSurface.Paint += new System.Windows.Forms.PaintEventHandler(this.drawSurface_Paint);


        }

        /**********************************************************************PAINT*/
        private void drawSurface_Paint(object sender, PaintEventArgs e)
        {
            // Good ol' graphics object.
            Graphics g = e.Graphics;

            /******************************************** DRAW TILES*/
                
                // Floor layer
                for (int i = 0; i < map.GetColumns(); i++)
                {
                    for (int j = 0; j < map.GetRows(); j++)
                    {
                        /* Draw the tiles dynamically based on where they are in the grid, 
                            and where the map root is set. 
                           This is the BOTTOM, or floor layer. This will always draw something. */
                        g.DrawImage(map.GetTileImage(i, j, Map.LAYER.FLOOR),
                                    (i * map.GetTileSize()) + map.GetMapRootX(),
                                    (j * map.GetTileSize()) + map.GetMapRootY(),
                                    map.GetTileSize(),
                                    map.GetTileSize());
                    }
                }

                // Decor layer
                for (int i = 0; i < map.GetColumns(); i++)
                {
                    for (int j = 0; j < map.GetRows(); j++)
                    {
                        /* Draw the tiles dynamically based on where they are in the grid, 
                            and where the map root is set. 
                           This is the TOP, or decor layer. This will only draw something if there is an
                           image specified for this layer. */

                        if (map.GetTiles()[i, j].GetTileImage(Map.LAYER.DECOR) != null) 
                        {
                            g.DrawImage(map.GetTileImage(i, j, Map.LAYER.DECOR),
                                        (i * map.GetTileSize()) + map.GetMapRootX(),
                                        (j * map.GetTileSize()) + map.GetMapRootY(),
                                        map.GetTileSize(),
                                        map.GetTileSize());
                        }
                    }
                }

            // Draw the grid if it is turned on.
            if (map.IsGridOn())
            {
                for (int i = 0; i < map.GetColumns(); i++)
                {
                    for (int j = 0; j < map.GetRows(); j++)
                    {
                        g.DrawRectangle(rectPen,
                                        (i * map.GetTileSize()) + map.GetMapRootX(),
                                        (j * map.GetTileSize()) + map.GetMapRootY(),
                                        map.GetTileSize(),
                                        map.GetTileSize());
                    }
                }
            }
        }

        /***************************************************************KEYBOARD EVENTS*/

        // Handles Alpha-Numeric key presses.
        void Form1_KeyPress(object sender, KeyPressEventArgs e) {}

        // This filters out arrow key presses when this button is selected on the windows form.
        private void floorButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) { CheckForArrowKeys(e); }
        private void decorButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) { CheckForArrowKeys(e); }

        /* If a non Alpha-Numeric key press is detected in IsInputKey() above, this is where
         you filter out the actual key pressed and handle it appropriately. */
        protected override void OnKeyDown(KeyEventArgs e) { HandleArrowKeyPress(e); }

        /* Handling arrow key events is quite convoluted in C#.  This method is the first step in
         capturing and processing non Alpha-Numeric key presses. This checks if any such keys were pressed,
         then passes the ball to the OnKeyDown() event below.
         THIS ONLY FIRES WHEN NO OTHER CONTROL AS BEEN CLICKED ON THE WINDOWS FORM. */
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                // Right now I am only checking for arrow key presses.
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }

        /* This method is do reduce copy and pasting the switch statement to determine which arrow keys are pressed. 
         Since windows is forcing me to override methods for OnPreviewKeyDown and OnKeyDown for EVERY button on the
         Windows form, I made this to make it a little more streamlined. */
        public void HandleArrowKeyPress(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // Moves the map based on which arrow key is pressed.
            switch (e.KeyCode)
            {
                case Keys.Left:
                    map.SetMapRootX(map.GetMapRootX() + map.GetScrollAmount());
                    this.Refresh(); // Must call refresh or you won't see any change on screen.
                    break;
                case Keys.Right:
                    map.SetMapRootX(map.GetMapRootX() - map.GetScrollAmount());
                    this.Refresh();
                    break;
                case Keys.Up:
                    map.SetMapRootY(map.GetMapRootY() - map.GetScrollAmount());
                    this.Refresh();
                    break;
                case Keys.Down:
                    map.SetMapRootY(map.GetMapRootY() + map.GetScrollAmount());
                    this.Refresh();
                    break;
            }
        }

        /*Again, since windows is making me check for arrow keys for EVERY button on the form, this method is just to streamline
         the process and reduce copy/pasting. This part just makes sure one of the arrow keys was pressed. */
        public void CheckForArrowKeys(PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        /*************************************************************MOUSE CLICKS*/

        // Click event for the floor select button.
        private void floorButton_Click(object sender, EventArgs e)
        {
            // Open the image select diaglog box and check if the user selected "OK"
            if (selectImageDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the image
                    Bitmap newImage = new Bitmap(Image.FromFile(selectImageDialog.FileName), ImagePalette.IMAGE_SIZE, ImagePalette.IMAGE_SIZE);

                     // Add it to the image palette
                    map.GetImagePalette().AddNewImage(selectImageDialog.FileName, newImage);

                    // Set the current paint layer.
                    map.SetCurrentLayer(Map.LAYER.FLOOR);

                    // Set the current image to paint.
                    map.GetImagePalette().SetCurrentImage(selectImageDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not load image: " + selectImageDialog.FileName);
                    Console.WriteLine("Could not load image: " + selectImageDialog.FileName);
                    Console.WriteLine(ex.ToString());
                }

            }

        }

        // Click event for the decor select button.
        private void decorButton_Click(object sender, EventArgs e)
        {
            // Open the image select diaglog box and check if the user selected "OK"
            if (selectImageDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the image
                    Bitmap newImage = new Bitmap(Image.FromFile(selectImageDialog.FileName), ImagePalette.IMAGE_SIZE, ImagePalette.IMAGE_SIZE);

                    // Add it to the image palette
                    map.GetImagePalette().AddNewImage(selectImageDialog.FileName, newImage);

                    // Set the current paint layer.
                    map.SetCurrentLayer(Map.LAYER.DECOR);

                    // Set the current image to paint.
                    map.GetImagePalette().SetCurrentImage(selectImageDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not load image: " + selectImageDialog.FileName);
                    Console.WriteLine("Could not load image: " + selectImageDialog.FileName);
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        // Called when the map is clicked.
        private void pictureBox_Click(object sender, EventArgs e)
        {
            // Figure out the location of the click.
            SetMouseLocation(MousePosition.X, MousePosition.Y);

            // Check if there is a current image selected. If there is, set the tile to it.
            if (map.GetImagePalette().GetCurrentImage() != null)
            {
                map.GetClickedTile(mouseLocation).SetTileImage(map.GetCurrentLayer(), map.GetImagePalette().GetCurrentImage());
                Refresh();
            }            
        }

        /* Sets the location of the mouse cursor on the map. Filters the location through any
            necessary offsets. */
        public void SetMouseLocation(int x, int y)
        {
            mouseLocation.X = x - map.GetMapRootX() - Location.X - drawSurface.Location.X - X_OFFSET;
            mouseLocation.Y = y - map.GetMapRootY() - Location.Y - drawSurface.Location.Y - Y_OFFSET;
        }

        // Sets the grid visibility to the opposite state of what it currently is.
        private void gridMenuBar_Click(object sender, EventArgs e)
        {
            map.ToggleGrid();
            Refresh();
        }

        // Click on save menu item button.
        private void saveMenuBar_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        /*************************************************************FILE HANDLING*/

        // Regular "Save" method.
        public void SaveMap()
        {
            // Check if this map has a name, meaning it has been saved before. If it hasn't, promt the user to name it using the "SaveAs()" method.
            if (map.GetMapName() == null)
                SaveAs();
            else
                MapIO.SaveMap(map);
        }

        // Method for saving a map with a new name.
        public void SaveAs()
        {
            // Prompt the user with a save file dialog box to get the path and file name for the map.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            { 
                map.SetMapName(saveFileDialog.FileName);
                MapIO.SaveMap(map);
            }
        }
    }
}
