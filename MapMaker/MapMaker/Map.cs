using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MapMaker
{
    /* This is the class that holds all of the information for the actual map, including: the number of tiles,
     which image is on each tiles, whether or not to show the grid, etc. */
    class Map
    {
        /****************************************MAP SETTINGS*/

            // The number of columns in the map grid.
            private int columns;

            // The number of rows in the grid.
            private int rows;

            // The default size to draw each tile.
            private const int DEFAULT_TILE_SIZE = 100;

            // The size in pixels to draw each tile.
            private int tileSize = DEFAULT_TILE_SIZE;

            // The current level of zoom magnification.
            private float zoomLevel = 1;

            // The highest possible value of zoom. Capped so the map can't be zoomed into the subatomic level.
            private float MAX_ZOOM = 1.5f;

            // The lowest possible value of zoom. Capped so the map can't be zoomed out into the void.
            private float MIN_ZOOM = .5f;

            // The amout of increase or decrease in an interation of zoom (in or out).
            private float zoomStep = .1f;

            // Determines if the grid should be shown.
            private bool isGridOn;

            // The coordinates to draw the map realative to the picture box the map is drawn in.
            private int mapRootX;
            private int mapRootY;

            // The number of pixels the map moves when it is scrolled with the arrow keys.
            private int scrollAmount = DEFAULT_TILE_SIZE;

            // The files name of this map.
            private String mapName = null;

        /***************************************IMAGE PALETTE*/

            // The object that stores all images used in the map.
            private ImagePalette imagePalette = new ImagePalette();

            // The default image to use in the event that a an image is missing.
            private static String DEFAULT_IMAGE =("Wood,horizontal.jpg");

        /*******************************************TILES*/

            // The array of tiles in the map.
            private Tile[,] TILES;

            // Different "states" of tiles. Determines where the current tile image goes on the map layer.
            public enum LAYER { FLOOR, WALL, DECOR };

            // The number of layers in the map.
            public static int NUMBER_OF_LAYERS;

            // Current layer the tiles are being placed on. Default is the floor layer
            private LAYER currentLayer = Map.LAYER.FLOOR;

        /**************************************MOUSE SCROLLING*/

            // The initial click location at the start of a mouse scroll.
            private int mouseScrollX;
            private int mouseScrollY;

        /**************************************CONSTRUCTOR*/
        /**************************************CONSTRUCTOR*/
        /**************************************CONSTRUCTOR*/

        // Creates a map with the supplied dimensions (in tiles, not pixels).
        public Map(int columns, int rows)
        {
            // Set up the map dimensions
            SetColumns(columns);
            SetRows(rows);
            SetIsGridOn(true);

            // Check if the map's dimensions were set and build the map if they were.
            if (columns > 0 && rows > 0)
                RebuildMap();

            /* This is a really dumb way to automatically count how many layers there are in the map.
             I coudn't find a decent way to to do that dynamically and it was too expensive to poll
             this value on every iteration of a loop, so I'm doing this on load and saving the value
             for all to share. */
            NUMBER_OF_LAYERS = Enum.GetValues(typeof(Map.LAYER)).Length;
        }

        /**************************************ACCESSORS*/
        /**************************************ACCESSORS*/
        /**************************************ACCESSORS*/

        public void     SetColumns(int numberOfColumns) { columns       =   numberOfColumns; }
        public int      GetColumns()                    { return            columns; }
        public void     SetRows(int numberOfRows)       { rows          =   numberOfRows; }
        public int      GetRows()                       { return            rows; }
        public void     SetTileSize(int sizeOfTile)     { tileSize      =   sizeOfTile; }
        public int      GetTileSize()                   { return            tileSize; }
        public void     SetIsGridOn(bool isTheGridOn)   { isGridOn      =   isTheGridOn; }
        public void     ToggleGrid()                    { isGridOn      =   !isGridOn; }
        public bool     IsGridOn()                      { return            isGridOn; }
        public void     SetMapRootX(int x)              { mapRootX      =   x; }
        public void     SetMapRootY(int y)              { mapRootY      =   y; }
        public int      GetMapRootX()                   { return            mapRootX; }
        public int      GetMapRootY()                   { return            mapRootY; }
        public void     SetScrollAmount(int amount)     { scrollAmount  =   amount; }
        public int      GetScrollAmount()               { return            scrollAmount; }
        public void     SetMouseScrollX(int x)          { mouseScrollX  =   x; }
        public int      GetMouseScrollX()               { return            mouseScrollX; }
        public void     SetMouseScrollY(int y)          { mouseScrollY  =   y; }
        public int      GetMouseScrollY()               { return            mouseScrollY; }
        public Tile[,]  GetTiles()                      { return            TILES; }
        public static String GetDefaultImage()          { return            DEFAULT_IMAGE; }
        public ImagePalette GetImagePalette()           { return            imagePalette; }
        public LAYER    GetCurrentLayer()               { return            currentLayer; }
        public void     SetCurrentLayer(LAYER l)        { currentLayer  =   l; }
        public void     SetMapName(String name)         { mapName       =   name; }
        public String   GetMapName()                    { return            mapName; }
        public void     SetZoomLevel(float zoom)          { zoomLevel     =   zoom; }
        public float    GetZoomLevel()                  { return            zoomLevel; }
        public void     SetZoomStep(float step)         { zoomStep      =   step; }
        public float    GetZoomStep()                   { return            zoomStep; }
        public float    GetMaxZoomLevel()               { return            MAX_ZOOM; }
        public float    GetMinZoomLevel()               { return            MIN_ZOOM; }

        // Retreives the image for the tile at the specified index, on the specified layer.
        public Bitmap GetTileImage(int x, int y, Map.LAYER layer)
        {
            return imagePalette.GetImage(TILES[x, y].GetTileImageKey(layer));
        }

        // Returns the tile that was clicked by the user.
        public Tile GetClickedTile(Point click)
        {
            int x = click.X / GetTileSize();
            int y = click.Y / GetTileSize();

            // Check to make sure the index number is not out of bounds of the array.
            if (x >= 0 && x <= (GetColumns() - 1) &&
                y >= 0 && y <= (GetRows() - 1))
            {
                return GetTiles()[x, y];
            }
            else
            {
                MessageBox.Show("Tile is out of bounds. Changed top left tile instead, loser.");
                return GetTiles()[0, 0];
            }
        }

        // Checks if the click was on a tile on the map, or out of the map bounds.
        public Boolean ClickedOnTile(Point click)
        {
            // Translate the click coordinates into an array index number.
            int x = click.X / GetTileSize();
            int y = click.Y / GetTileSize();

            // FIRST: make sure either of the coordinates aren't negative, and therefore out of bounds.
            if (click.X >= 0 && click.Y >= 0)
            {
                // SECOND: Check to make sure the index number is not out of bounds of the array.
                if (x >= 0 && x <= (GetColumns() - 1) &&
                    y >= 0 && y <= (GetRows() - 1))
                {
                    return true;
                }
            }

            return false;
        }

        // Rebuilds the tile array. Usually called after the map's rows and columns have changed.
        public void RebuildMap()
        {
            /* Check to make sure the values for rows and columns are't negative numbers or zero. 
             Set them to 1 if they are. */
            if (GetRows() <= 0)
                SetRows(1);

            if (GetColumns() <= 0)
                SetColumns(1);

            // Initialize the Tile array based on the above dimensions.
            TILES = new Tile[columns, rows];

            for (int i = 0; i < columns; i++)
                for (int j = 0; j < rows; j++)
                    TILES[i, j] = new Tile();

            FillFloor(GetDefaultImage());
        }

        // Sets every floor tile to the passed image.
        public void FillFloor(String image)
        {
            // Loop through every tile and change the image to the passed image argument.
            for(int i = 0; i < GetColumns(); i++)
                for(int j = 0; j < GetRows(); j++)
                    GetTiles()[i,j].SetTileImage(Map.LAYER.FLOOR, image);
        }

        /***************************************MAP SCROLLING*/
        /***************************************MAP SCROLLING*/
        /***************************************MAP SCROLLING*/

        // Keyboard scroll left.
        public void ScrollLeft(){SetMapRootX(GetMapRootX() + GetScrollAmount());}

        // Keyboard scroll right.
        public void ScrollRight(){SetMapRootX(GetMapRootX() - GetScrollAmount());}

        // Keyboard scroll up.
        public void ScrollUp(){SetMapRootY(GetMapRootY() + GetScrollAmount());}

        // Keyboard scroll down.
        public void ScrollDown(){SetMapRootY(GetMapRootY() - GetScrollAmount());}

        // Mouse Scrolling
        public void ScrollMouse(int x, int y)
        {
            // Find the distance (in pixels) between the current mouse position and the previous mouse scroll location.
            int newX = x - GetMouseScrollX();
            int newY = y - GetMouseScrollY();

            // Set the map root coordinates based on the above distance.
            SetMapRootX(GetMapRootX() + newX);
            SetMapRootY(GetMapRootY() + newY);

            // Update the map scroll location to the current mouse location.
            SetMouseScrollX(x);
            SetMouseScrollY(y);
        }

        /******************************************MAP ZOOMING*/
        /******************************************MAP ZOOMING*/
        /******************************************MAP ZOOMING*/

        // Increases the zoom level.
        public void ZoomIn()
        {
            // Make sure the zoom level hasn't exceeded the maximum allowed level.
            if(GetZoomLevel() <= GetMaxZoomLevel())
            {
                // Increase the zoom level by one step.
                SetZoomLevel(GetZoomLevel() + GetZoomStep());

                // Record the old tile size (in pixels).
                int previousTileSize = GetTileSize();

                // Set the new tile size.
                int newTileSize = (int)(DEFAULT_TILE_SIZE * GetZoomLevel());

                // Change the tile size to the new size.
                SetTileSize(newTileSize);

                // Set the map root location. We change this so the view stays centered when the map is zoomed in/out.
                AdjustMapRootBasedOnZoom(previousTileSize, newTileSize);
            }
        }

        // Decreases the zoom level.
        public void ZoomOut()
        {
            // Make sure the zoom level hasn't exceeded the minimum allowed level.
            if (GetZoomLevel() >= GetMinZoomLevel())
            {
                // Increase the zoom level by one step.
                SetZoomLevel(GetZoomLevel() - GetZoomStep());

                // Record the old tile size (in pixels).
                int previousTileSize = GetTileSize();

                // Set the new tile size.
                int newTileSize = (int)(DEFAULT_TILE_SIZE * GetZoomLevel());

                // Change the tile size to the new size.
                SetTileSize(newTileSize);

                // Set the map root location. We change this so the view stays centered when the map is zoomed in/out.
                AdjustMapRootBasedOnZoom(previousTileSize, newTileSize);
            }
        }

        // Adjusts the map root location after the zoom level has changed.
        public void AdjustMapRootBasedOnZoom(int previousSize, int newSize)
        {
            int sizeDifference = previousSize - newSize;

            SetMapRootX(GetMapRootX() + ((sizeDifference / 2) * GetColumns()));
            SetMapRootY(GetMapRootY() + ((sizeDifference / 2) * GetRows()));
        }
    }
}
