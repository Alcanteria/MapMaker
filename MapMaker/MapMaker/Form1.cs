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
            private PictureBox DRAW_SURFACE;

            // Declare versions of buttons to interact with.
            private Button FLOOR_BUTTON;
            private Button WALL_BUTTON;
            private Button DECOR_BUTTON;
            private Button ERASE_BUTTON;

            // Dialog box for selecting image files.
            OpenFileDialog selectImageDialog = new OpenFileDialog();

            // Dialog box for selecting maps to open.
            OpenFileDialog selectMapDialog = new OpenFileDialog();

            // Dialog box for saving files.
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Dialog box for exporting image files.
            SaveFileDialog exportFileDialog = new SaveFileDialog();

            // Dialog for creating a new map.
            private newMapDialog createMapDialog;

            // Pen for drawing the grid.
            Pen rectPen = new Pen(Color.Black);

            // Group box for containing the layer radio buttons.
            GroupBox LAYER_GROUP_BOX;

            // Radio button for floor layer select.
            RadioButton FLOOR_LAYER_RADIO;

            // Radio button for wall layer.
            RadioButton WALL_LAYER_RADIO;

            // Radio button for decor layer.
            RadioButton DECOR_LAYER_RADIO;

        /*********************************************MOUSE CLICKS*/

            // This is an offest that compensates for a slight variance in click position.
            private const int X_OFFSET = 10;
            private const int Y_OFFSET = 33;

            // Location of the current mouse click on the map, filtered through any necessary offsets.
            private Point mouseLocation = new Point();

        /****************************************************MISC*/

            // Boolean to check the current state of erasing.
            private bool isErasing;

        public mainForm()
        {
            InitializeComponent();

            // Set up the key press listener.
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);

            // Link our draw surface to the picture box on the windows form.
            DRAW_SURFACE = pictureBox;

            // Add the key listeners to the buttons on the form. This is to filter out arrow key presses when a button is selected.
            floorButton.PreviewKeyDown += new PreviewKeyDownEventHandler(floorButton_PreviewKeyDown);
            wallButton.PreviewKeyDown += new PreviewKeyDownEventHandler(wallButton_PreviewKeyDown);
            decorButton.PreviewKeyDown += new PreviewKeyDownEventHandler(decorButton_PreviewKeyDown);
            eraseButton.PreviewKeyDown += new PreviewKeyDownEventHandler(eraseButton_PreviewKeyDown);

            // Link our buttons to the form buttons
            FLOOR_BUTTON = floorButton;
            WALL_BUTTON = wallButton;
            DECOR_BUTTON = decorButton;
            ERASE_BUTTON = eraseButton;

            // Link the group box to a local copy.
            LAYER_GROUP_BOX = layerGroupBox;

            // Link radio buttons to local copies.
            FLOOR_LAYER_RADIO = floorRadioButton;
            WALL_LAYER_RADIO = wallRadioButton;
            DECOR_LAYER_RADIO = decorRadioButton;

            // Attached the event listeners for the radio buttons.
            FLOOR_LAYER_RADIO.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            WALL_LAYER_RADIO.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            DECOR_LAYER_RADIO.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);

            // Adjust the size of the main window based on the scale we've set above.
            this.Width  = (int)(screenWidth * SCREEN_SCALE);
            this.Height = (int)(screenHeight * SCREEN_SCALE);

            // Set the size of the drawing surface based on the main window's properties.
            DRAW_SURFACE.Size = new Size((int)(Width * DRAWING_SURFACE_SCALE), (int)(Height * DRAWING_SURFACE_SCALE));
          
            // Open image dialog box properties
            selectImageDialog.Filter = "Image Files (*.bmp, *.gif, *.jpg, *.png)|*.bmp; *.gif; *.jpg; *.png";
            selectImageDialog.Multiselect = false;

            // Open file dialog box properties.
            selectMapDialog.Filter = "Text Files (*.txt)|*.txt";
            selectMapDialog.Multiselect = false;

            // Save file dialog box properties.
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog.RestoreDirectory = true;

            // Export file dialog box properties.
            exportFileDialog.Filter = "Image Files (*.png)|*.png";

            // Initiialize the new map dialog box.
            createMapDialog = new newMapDialog(this);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the starting location of the main window.
            this.Location = new Point((int)(screenWidth * .05f), (int)(screenHeight * .05f));

            // Set the location of the buttons.
            //FLOOR_BUTTON.Location = new Point(20, 50);
            //WALL_BUTTON.Location = new Point(FLOOR_BUTTON.Location.X, FLOOR_BUTTON.Location.Y + (FLOOR_BUTTON.Height + 5));
            //DECOR_BUTTON.Location = new Point(FLOOR_BUTTON.Location.X, WALL_BUTTON.Location.Y + (WALL_BUTTON.Height + 5));

            // Set the starting location of the drawing space. This is based off of the location of the buttons.
            DRAW_SURFACE.Location = new Point(FLOOR_BUTTON.Location.X + (FLOOR_BUTTON.Width + 5), LAYER_GROUP_BOX.Location.Y);            

            // Link the paint event of our draw surface to the windows event cycle
            DRAW_SURFACE.Paint += new System.Windows.Forms.PaintEventHandler(this.drawSurface_Paint);


        }

        /**********************************************************************PAINT*/
        private void drawSurface_Paint(object sender, PaintEventArgs e)
        {
            // Good ol' graphics object.
            Graphics g = e.Graphics;

            /******************************************** DRAW TILES*/

            /* This is a work around for not being able to iterate through elements in an Enum. We have to create a string
                array that contains the names of each element in the enum, then cycle through each element in the string array instead. */
            String[] LAYERS = Enum.GetNames(typeof(Map.LAYER));

            // Draw each layer of the map separately, starting with the floor.
            foreach (String currentElement in LAYERS)
            {
                // Convert the current element string to our Enum type "Layer"
                Map.LAYER THIS_LAYER = (Map.LAYER)Enum.Parse(typeof(Map.LAYER), currentElement);

                // Iterate through every tile and draw its appropriate layer image.
                for (int i = 0; i < map.GetColumns(); i++)
                {
                    for (int j = 0; j < map.GetRows(); j++)
                    {
                        // Check if this layer is not the floor. If it is, just draw it and don't worry about anything else.
                        if (THIS_LAYER != Map.LAYER.FLOOR)
                        {
                            // If this layer isn't the floor, make sure it isn't empty before you draw it.
                            if (!map.GetTiles()[i, j].IsTileLayerEmpty(THIS_LAYER))
                                DrawTile(g, i, j, THIS_LAYER);
                        }
                        else
                            DrawTile(g, i, j, THIS_LAYER);
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

        // Cycle through each tile in the map and draw it.
        private void DrawTile(Graphics g, int x, int y, Map.LAYER layer)
        {
            g.DrawImage(map.GetTileImage(x, y, layer),
                (x * map.GetTileSize()) + map.GetMapRootX(),
                (y * map.GetTileSize()) + map.GetMapRootY(),
                     map.GetTileSize(),
                     map.GetTileSize());
        }

        /***************************************************************KEYBOARD EVENTS*/

        // Handles Alpha-Numeric key presses.
        void Form1_KeyPress(object sender, KeyPressEventArgs e) {}

        // This filters out arrow key presses when this button is selected on the windows form.
        private void floorButton_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e) { CheckForArrowKeys(e); }
        private void wallButton_PreviewKeyDown  (object sender, PreviewKeyDownEventArgs e) { CheckForArrowKeys(e); }
        private void decorButton_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e) { CheckForArrowKeys(e); }
        private void eraseButton_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e) { CheckForArrowKeys(e); }

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

        // Click event for the FLOOR select button.
        private void floorButton_Click(object sender, EventArgs e)
        {
            // Set erasing to off.
            isErasing = false;

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

        // Click event for the WALL select button.
        private void wallButton_Click(object sender, EventArgs e)
        {
            // Set erasing to off.
            isErasing = false;

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
                    map.SetCurrentLayer(Map.LAYER.WALL);

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

        // Click event for the DECOR select button.
        private void decorButton_Click(object sender, EventArgs e)
        {
            // Set erasing to off.
            isErasing = false;

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

        // Click event for the ERASE button.
        private void eraseButton_Click(object sender, EventArgs e)
        {
            // Set erasing to on.
            isErasing = true;
        }

        // Called when the map is clicked.
        private void pictureBox_Click(object sender, EventArgs e)
        {
            // Figure out the location of the click.
            SetMouseLocation(MousePosition.X, MousePosition.Y);

            // Check if erasing is turned on.
            if (isErasing)
            {
                map.GetClickedTile(mouseLocation).SetTileImage(map.GetCurrentLayer(), Tile.NO_IMAGE);
                Refresh();
            }
            // Check if there is a current image selected. If there is, set the tile to it.
            else if (map.GetImagePalette().GetCurrentImage() != null)
            {
                map.GetClickedTile(mouseLocation).SetTileImage(map.GetCurrentLayer(), map.GetImagePalette().GetCurrentImage());
                Refresh();
            }            
        }

        /* Sets the location of the mouse cursor on the map. Filters the location through any
            necessary offsets. */
        public void SetMouseLocation(int x, int y)
        {
            mouseLocation.X = x - map.GetMapRootX() - Location.X - DRAW_SURFACE.Location.X - X_OFFSET;
            mouseLocation.Y = y - map.GetMapRootY() - Location.Y - DRAW_SURFACE.Location.Y - Y_OFFSET;
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

        // Method for creating a new blank map.
        public void CreateNewMap(int x, int y)
        {
            map = new Map(x, y);
            Refresh();
        }

        // Method for loading a saved map.
        private void openMenuBar_Click(object sender, EventArgs e)
        {
            // Open the file select diaglog box and check if the user selected "OK"
            if (selectMapDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    map = MapIO.LoadMap(selectMapDialog.FileName);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not load map: " + selectMapDialog.FileName);
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        /* Shows the dialog box to configure a new map. */
        private void newMenuBar_Click(object sender, EventArgs e)
        {
            createMapDialog.Show();
        }

        /* Exports the map to a png file named by the user. */
        private void exportMenuBar_Click(object sender, EventArgs e)
        {
            if (exportFileDialog.ShowDialog() == DialogResult.OK)
            {
                MapIO.ExportMap(map, exportFileDialog.FileName);
            }
        }

        /***********************************TEST BUTTON*/
        private void testButtonMenuItem_Click(object sender, EventArgs e){ }

        /*********************************************************RADIO BUTTONS*/

        private void radioButtons_CheckedChanged(Object sender, EventArgs e)
        {
            // Check which radio button was selected and change the current layer accordingly.
            if (FLOOR_LAYER_RADIO.Checked)
                map.SetCurrentLayer(Map.LAYER.FLOOR);
            else if (WALL_LAYER_RADIO.Checked)
                map.SetCurrentLayer(Map.LAYER.WALL);
            else if (DECOR_LAYER_RADIO.Checked)
                map.SetCurrentLayer(Map.LAYER.DECOR);
        }
    }
}
