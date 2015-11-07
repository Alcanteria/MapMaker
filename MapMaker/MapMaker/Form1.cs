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
            private Map testMap = new Map(10, 10);

        /********************************************WINDOWS FORM PARTS*/

            // Declare a version of the picture box to use to draw on to.
            private PictureBox drawSurface;

            // Declare versions of buttons to interact with.
            private Button FLOOR_BUTTON;
            private Button DECOR_BUTTON;

            // Dialog box for selecting image files.
            OpenFileDialog selectImageDialog = new OpenFileDialog();

            // Pen for drawing the grid.
            Pen rectPen = new Pen(Color.Black);

        public mainForm()
        {
            InitializeComponent();

            // Set up the key press listener.
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);

            // Link our draw surface to the picture box on the windows form.
            drawSurface = pictureBox;

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

        // This is where drawing is actually done.
        private void drawSurface_Paint(object sender, PaintEventArgs e)
        {
            // Good ol' graphics object.
            Graphics g = e.Graphics;

            // Draw the test tiles.
            for (int i = 0; i < testMap.GetColumns(); i++)
            {
                for (int j = 0; j < testMap.GetRows(); j++)
                {
                    /* Draw the tiles dynamically based on where they are in the grid, 
                        and where the map root is set. */
                    g.DrawImage(testMap.GetTileImage(i, j),
                                (i * testMap.GetTileSize()) + testMap.GetMapRootX(),
                                (j * testMap.GetTileSize()) + testMap.GetMapRootY(),
                                testMap.GetTileSize(),
                                testMap.GetTileSize());
                }
            }

            // Draw the grid if it is turned on.
            if (testMap.IsGridOn())
            {
                for (int i = 0; i < testMap.GetColumns(); i++)
                {
                    for (int j = 0; j < testMap.GetRows(); j++)
                    {
                        g.DrawRectangle(rectPen,
                                        (i * testMap.GetTileSize()) + testMap.GetMapRootX(),
                                        (j * testMap.GetTileSize()) + testMap.GetMapRootY(),
                                        testMap.GetTileSize(),
                                        testMap.GetTileSize());
                    }
                }
            }
        }

        /***************************************************************KEYBOARD EVENTS*/

        // Handles Alpha-Numeric key presses.
        void Form1_KeyPress(object sender, KeyPressEventArgs e) {}
        
        /* Handling arrow key events is quite convoluted in C#.  This method is the first step in
         capturing and processing non Alpha-Numeric key presses. This checks if any such keys were pressed,
         then passes the ball to the OnKeyDown() event below. */
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

        /* If a non Alpha-Numeric key press is detected in IsInputKey() above, this is where
         you filter out the actual key pressed and handle it appropriately. */
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.Left:
                    testMap.SetMapRootX(testMap.GetMapRootX() + testMap.GetScrollAmount());
                    this.Refresh(); // Must call refresh or you won't see any change on screen.
                    break;
                case Keys.Right:
                    testMap.SetMapRootX(testMap.GetMapRootX() - testMap.GetScrollAmount());
                    this.Refresh();
                    break;
                case Keys.Up:
                    testMap.SetMapRootY(testMap.GetMapRootY() - testMap.GetScrollAmount());
                    this.Refresh();
                    break;
                case Keys.Down:
                    testMap.SetMapRootY(testMap.GetMapRootY() + testMap.GetScrollAmount());
                    this.Refresh();
                    break;
            }
        }

        /*************************************************************BUTTON CLICKS*/

        // Click event for the floor select button.
        private void floorButton_Click(object sender, EventArgs e)
        {
            // Open the image select diaglog box and check if the user selected "OK"
            if (selectImageDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap newImage = new Bitmap(Image.FromFile(selectImageDialog.FileName), 100, 100);
                newImage.Save("C:\\Users\\Nick\\Desktop\\newImage.jpeg", ImageFormat.Jpeg);
            }
        }

        // Click event for the decor select button.
        private void decorButton_Click(object sender, EventArgs e)
        {

        }

        /*************************************************************FILE HANDLING*/
    }
}
