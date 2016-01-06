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
using System.Timers;
using System.Reflection;
using System.IO;

namespace MapMaker
{
    public partial class mainForm : Form
    {
        /*******************************SCREEN DIMENSIONS*/

        // Get the dimensions of the primary monitor.
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        // The scale you want to draw the main window size to.
        private const float SCREEN_SCALE = .90f;

        // The size of the drawing surface as a percentage of the main window's size.
        private const float DRAWING_SURFACE_SCALE = .85f;

        /**********************************MAP PARTS*/

        // Map object.
        private Map map = new Map(10, 10);

        /******************************WINDOWS FORM PARTS*/

        // Declare a version of the picture box to use to draw on to.
        private PictureBox DRAW_SURFACE;

        // Declare a local version of the picture box to draw the image preivew on.
        private PictureBox PREIVEW_BOX;

        // Declare versions of buttons to interact with.
        private Button LOAD_IMAGE_BUTTON;
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

        // The size of the current image preview box.
        int PREVIEW_SIZE = 50;

        // Create the splash screen.
        //SplashScreen SPLASH_SCREEN = new SplashScreen();

        /******************************RECENT PICTURES*/

            // Array to store each preivew box
            private PictureBox[] recentPictures = new PictureBox[10];

            // The default size of the recent pictures boxes.
            private int RECENT_PICTURE_SIZE = 40;

            // Flag for an empty picture box.
            public String NO_RECENT_IMAGE = "NO RECENT IMAGE";

        /********************************MOUSE CLICKS*/

        // This is an offest that compensates for a slight variance in click position.
        private const int X_OFFSET = 10;
        private const int Y_OFFSET = 33;

        // Location of the current mouse click on the map, filtered through any necessary offsets.
        private Point currentMouseLocation = new Point();

        /****************************************************STATE CHECKS*/

        // Boolean to check the current state of erasing.
        private bool isErasing;

        // Boolean to check if the map is mouse scrolling.
        private bool isMouseScrolling;

        // Boolean to check if the splash screen is showing.
        private bool isSplashScreenShowing = true;

        public mainForm()
        {
            InitializeComponent();

            // Set up the key listener.
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);

            // Link our draw surface to the picture box on the windows form.
            DRAW_SURFACE = pictureBox;

            // Link our preview box to the local version.
            PREIVEW_BOX = currentImageDisplay;

            // Add the key listeners to the buttons on the form. This is to filter out arrow key presses when a button is selected.
            loadImageButton.PreviewKeyDown  += new PreviewKeyDownEventHandler(loadImageButton_PreviewKeyDown);
            eraseButton.PreviewKeyDown      += new PreviewKeyDownEventHandler(eraseButton_PreviewKeyDown);
            floorRadioButton.PreviewKeyDown += new PreviewKeyDownEventHandler(floorRadioButton_PreviewKeyDown);
            wallRadioButton.PreviewKeyDown  += new PreviewKeyDownEventHandler(wallRadioButton_PreviewKeyDown);
            decorRadioButton.PreviewKeyDown += new PreviewKeyDownEventHandler(decorRadioButton_PreviewKeyDown);

            // Link our buttons to the form buttons
            LOAD_IMAGE_BUTTON = loadImageButton;
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
            this.Width = (int)(screenWidth * SCREEN_SCALE);
            this.Height = (int)(screenHeight * SCREEN_SCALE);

            // Set the size of the drawing surface based on the main window's properties.
            DRAW_SURFACE.Size = new Size((int)(Width * DRAWING_SURFACE_SCALE), (int)(Height * DRAWING_SURFACE_SCALE));

            // Set the size of the preview box.
            PREIVEW_BOX.Size = new Size(PREVIEW_SIZE, PREVIEW_SIZE);

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

            // Set the description text for the zoom in/out shortcut keys.
            this.zoomInToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl +";
            this.zoomOutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl -";

            // Link all of the preview picture boxes to the elements in the picture box array.
            recentPictures[0] = recent0;
            recentPictures[1] = recent1;
            recentPictures[2] = recent2;
            recentPictures[3] = recent3;
            recentPictures[4] = recent4;
            recentPictures[5] = recent5;
            recentPictures[6] = recent6;
            recentPictures[7] = recent7;
            recentPictures[8] = recent8;
            recentPictures[9] = recent9;

            // Set all of the image tags in the recent pictures array to emtpy and set their size.
            for (int i = 0; i < recentPictures.Length; i++)
            {
                recentPictures[i].Tag = NO_RECENT_IMAGE;
                recentPictures[i].Width = RECENT_PICTURE_SIZE;
                recentPictures[i].Height = RECENT_PICTURE_SIZE;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the starting location of the main window.
            this.Location = new Point((int)(screenWidth * .05f), (int)(screenHeight * .05f));

            // Set the starting location of the drawing space. This is based off of the location of the buttons.
            DRAW_SURFACE.Location = new Point(LOAD_IMAGE_BUTTON.Location.X + (LOAD_IMAGE_BUTTON.Width + 5), LAYER_GROUP_BOX.Location.Y);

            // Link the paint event of our draw surface to the windows event cycle
            DRAW_SURFACE.Paint += new System.Windows.Forms.PaintEventHandler(this.drawSurface_Paint);

            // Set up the mouse enter/exit listeners for the draw space.
            DRAW_SURFACE.MouseEnter += new System.EventHandler(pictureBox_MouseEnter);
            DRAW_SURFACE.MouseLeave += new System.EventHandler(pictureBox_MouseEnter);

            DRAW_SURFACE.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
            DRAW_SURFACE.MouseUp += new MouseEventHandler(pictureBox_MouseUp);
            DRAW_SURFACE.MouseMove += new MouseEventHandler(pictureBox_MouseMove);

            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }

        /**********************************************************************PAINT*/
        /**********************************************************************PAINT*/
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

        // Draw the tile image at the passed X/Y location.
        private void DrawTile(Graphics g, int x, int y, Map.LAYER layer)
        {
            
            g.DrawImage(map.GetTileImage(x, y, layer),
                        (x * map.GetTileSize()) + map.GetMapRootX(),
                        (y * map.GetTileSize()) + map.GetMapRootY(),
                            map.GetTileSize(),
                            map.GetTileSize());
        }

        /***************************************************************KEYBOARD EVENTS*/
        /***************************************************************KEYBOARD EVENTS*/
        /***************************************************************KEYBOARD EVENTS*/

        // Handles Alpha-Numeric key presses.
        void Form1_KeyPress(object sender, KeyPressEventArgs e) {}


        // This filters out arrow key presses when this button is selected on the windows form.
        private void loadImageButton_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e) { CheckForArrowKeys(e); }
        private void eraseButton_PreviewKeyDown     (object sender, PreviewKeyDownEventArgs e) { CheckForArrowKeys(e); }
        private void floorRadioButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) { CheckForArrowKeys(e); }
        private void wallRadioButton_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e) { CheckForArrowKeys(e); }
        private void decorRadioButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) { CheckForArrowKeys(e); }

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
                    map.ScrollLeft();
                    this.Refresh(); // Must call refresh or you won't see any change on screen.
                    break;
                case Keys.Right:
                    map.ScrollRight();
                    this.Refresh();
                    break;
                case Keys.Up:
                    map.ScrollUp();
                    this.Refresh();
                    break;
                case Keys.Down:
                    map.ScrollDown();
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

        /*************************************************************MOUSE EVENTS*/
        /*************************************************************MOUSE EVENTS*/
        /*************************************************************MOUSE EVENTS*/

        // Click event for the FLOOR select button.
        private void loadImageButton_Click(object sender, EventArgs e)
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

            UpdateCurrentImagePreview();

        }

        // Click event for the ERASE button.
        private void eraseButton_Click(object sender, EventArgs e)
        {
            // Set erasing to on.
            isErasing = !isErasing;
        }

        // Called when the map is clicked.
        private void pictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            // LEFT MOUSE BUTTON------------------------------------
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Figure out the location of the click.
                SetMouseLocation(MousePosition.X, MousePosition.Y);

                // Check if erasing is turned on.
                if (isErasing)
                {
                    // Make sure a valid tile was clicked.
                    if (map.ClickedOnTile(currentMouseLocation))
                    {
                        map.GetClickedTile(currentMouseLocation).SetTileImage(map.GetCurrentLayer(), Tile.NO_IMAGE);
                        Refresh();
                    }
                }
                // Check if there is a current image selected. If there is, set the tile to it.
                else if (map.GetImagePalette().GetCurrentImage() != null)
                {
                    // Make sure a valid tile was clicked.
                    if (map.ClickedOnTile(currentMouseLocation))
                    {
                        map.GetClickedTile(currentMouseLocation).SetTileImage(map.GetCurrentLayer(), map.GetImagePalette().GetCurrentImage());
                        Refresh();
                    }
                }
            }

            // RIGHT MOUSE BUTTON-----------------------------------
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
            
            }

        }
        
        // Mouse down event.
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Check to see if the right mouse button was the button that was clicked.
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                isMouseScrolling = true;

                // Set the location of the initial mouse click.
                map.SetMouseScrollX(e.X);
                map.SetMouseScrollY(e.Y);
            }
        }

        // Mouse up event.
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Check to see if the right mouse button was the button that was clicked.
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                isMouseScrolling = false;
            }
        }

        // Mouse move event.
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if mouse scrolling is active and pass the mouse location to the mouse scroll method if it is.
            if (isMouseScrolling)
            {
                this.map.ScrollMouse(e.X, e.Y);
                Refresh();
            }
        }
        
        /* Sets the location of the mouse cursor on the map. Filters the location through any
            necessary offsets. */
        public void SetMouseLocation(int x, int y)
        {
            currentMouseLocation.X = x - map.GetMapRootX() - Location.X - DRAW_SURFACE.Location.X - X_OFFSET;
            currentMouseLocation.Y = y - map.GetMapRootY() - Location.Y - DRAW_SURFACE.Location.Y - Y_OFFSET;
        }

        // Handles the mousewheel events.
        private void Form1_MouseWheel(Object sender, MouseEventArgs e)
        {
            // Check which direction the mousewheel was rolled and act accordingly.
            if(e.Delta >= 0)
            {
                map.ZoomIn();
                Refresh();
            }
            else
            {
                map.ZoomOut();
                Refresh();
            }
                
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

        // Method for the "Fill Floor" button on the menu bar.
        private void fillFloorToolStripMenuItem_Click(object sender, EventArgs e)
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

                    // Call the FillFloor() method, passing the loaded image to it.
                    map.FillFloor(selectImageDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not load image: " + selectImageDialog.FileName);
                    Console.WriteLine("Could not load image: " + selectImageDialog.FileName);
                    Console.WriteLine(ex.ToString());
                }

            }

            Refresh();
        }

        /*************************************************************FILE HANDLING*/
        /*************************************************************FILE HANDLING*/
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
            map.RebuildMap();
            map.GetImagePalette().PrintImageList();
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

        // Zoom in menu bar item.
        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.ZoomIn();
            Refresh();
        }

        // Zoom out menu bar item.
        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.ZoomOut();
            Refresh();
        }

        /***********************************TEST BUTTON*/
        private void testButtonMenuItem_Click(object sender, EventArgs e) {}

        /*********************************************************RADIO BUTTONS*/
        /*********************************************************RADIO BUTTONS*/
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

        /******************************************************CURRENT IMAGE PREVIEW BOX*/
        /******************************************************CURRENT IMAGE PREVIEW BOX*/
        /******************************************************CURRENT IMAGE PREVIEW BOX*/

        // Updates the image drawn in the current image preview box.
        public void UpdateCurrentImagePreview()
        {
            // Make a copy of the current image.
            Bitmap copy = new Bitmap((Image)map.GetImagePalette().GetImage(map.GetImagePalette().GetCurrentImage()).Clone());

            // Scale it down to the size of the preview box.
            Bitmap preview = new Bitmap(copy, PREVIEW_SIZE, PREVIEW_SIZE);

            // Scale another copy down to the size of the recent image boxes.
            Bitmap recent = new Bitmap(copy, RECENT_PICTURE_SIZE, RECENT_PICTURE_SIZE);

            // Pass the selected image name and scaled down copy to the recent image list.
            AddToRecentTiles(map.GetImagePalette().GetCurrentImage(), recent);

            // Set the preview display to the new scaled image and refresh the screen.
            currentImageDisplay.Image = preview;
            Refresh();
        }

        /***********************************************************RECENT TILES BOXES*/
        /***********************************************************RECENT TILES BOXES*/
        /***********************************************************RECENT TILES BOXES*/

        // Adds the passed picture to the recently used tiles list if it isn't already in there.
        public void AddToRecentTiles(String name, Bitmap image)
        {
            if (!IsImageInRecentTileList(name))
                InsertRecentTile(name, image);
        }

        // Check if the passed image is already in the recent tiles list.
        public bool IsImageInRecentTileList(String name)
        {
            for (int i = 0; i < recentPictures.Length; i++)
            {
                if (recentPictures[i].Tag.ToString() == name)
                    return true;
            }

            return false;
        }

        // Places the passed image into the recent tiles list and pushes older tiles to the end of the list.
        public void InsertRecentTile(String name, Bitmap image)
        {
            // Get the first open spot on the rencent tile list.
            int spot = FindOpenSpotOnRecentTilelist();

            // Check if "spot" is a negative number, which indicates the list is full.
            if (spot < 0)
            {
                // Set the last tile in the list to empty.
                recentPictures[recentPictures.Length - 1].Tag = NO_RECENT_IMAGE;

                // Set "spot" to the end of the array. We need this for the next step.
                spot = recentPictures.Length - 1;
            }

            // Loop through every tile in the list starting with the first open tile and stopping BEFORE the first tile.
            // The first tile is set after the looop.
            for (int i = spot; i > 0; i--)
            {
                recentPictures[i].Tag = recentPictures[i - 1].Tag;
                recentPictures[i].Image = recentPictures[i - 1].Image;
            }

            // Set the first tile in the list to the tile passed to this method.
            recentPictures[0].Tag = name;
            recentPictures[0].Image = image;
        }

        // Finds the first open spot in the recent tile list.
        public int FindOpenSpotOnRecentTilelist()
        {
            // Default value is -1. If this returns the negative number, we know the list is full.
            int result = -1;

            for (int i = 0; i < recentPictures.Length; i++)
            {
                // Find the spot with a tag of "No Image"
                if (recentPictures[i].Tag.ToString() == NO_RECENT_IMAGE) 
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        // Handles the clicking of a recent tile button.
        public void ProcessRecentTileClick(String name)
        {
            // Make sure the tile isn't empty before you assign it to the new current tile.
            if (name != NO_RECENT_IMAGE)
            {
                map.GetImagePalette().SetCurrentImage(name);

                // Make sure you turn erasing off!
                isErasing = false;
            }

            UpdateCurrentImagePreview();
        }

        // Filter the clicks on the recent tile buttons.
        private void recent0_Click(object sender, EventArgs e) { ProcessRecentTileClick(recent0.Tag.ToString()); }
        private void recent1_Click(object sender, EventArgs e) { ProcessRecentTileClick(recent1.Tag.ToString()); }
        private void recent2_Click(object sender, EventArgs e) { ProcessRecentTileClick(recent2.Tag.ToString()); }
        private void recent3_Click(object sender, EventArgs e) { ProcessRecentTileClick(recent3.Tag.ToString()); }
        private void recent4_Click(object sender, EventArgs e) { ProcessRecentTileClick(recent4.Tag.ToString()); }
        private void recent5_Click(object sender, EventArgs e) { ProcessRecentTileClick(recent5.Tag.ToString()); }
        private void recent6_Click(object sender, EventArgs e) { ProcessRecentTileClick(recent6.Tag.ToString()); }
        private void recent7_Click(object sender, EventArgs e) { ProcessRecentTileClick(recent7.Tag.ToString()); }
        private void recent8_Click(object sender, EventArgs e) { ProcessRecentTileClick(recent8.Tag.ToString()); }
        private void recent9_Click(object sender, EventArgs e) { ProcessRecentTileClick(recent9.Tag.ToString()); }

        /****************************************************CURSOR CHANGING*/
        /****************************************************CURSOR CHANGING*/
        /****************************************************CURSOR CHANGING*/

        // Event for when the mouse cursor enters the drawing space.
        private void pictureBox_MouseEnter(Object sender, System.EventArgs e)
        {
            // If the draw mode is set to erase, change the cursor to the crosshairs.
            if (isErasing)
                pictureBox.Cursor = Cursors.Cross;
            else
                pictureBox.Cursor = Cursors.Arrow;
        }

        // Event for when the mouse exits the draw space.
        private void pictureBox_MouseLeave(Object sender, System.EventArgs e){}


        /************************************************************TIMER EVENT*/
        /************************************************************TIMER EVENT*/
        /************************************************************TIMER EVENT*/

        

    }
}
