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

            // Determines if the grid should be shown.
            private bool isGridOn;

            // The coordinates to draw the map realative to the picture box the map is drawn in.
            private int mapRootX;
            private int mapRootY;

            // The number of pixels the map moves when it is scrolled with the arrow keys.
            private int scrollAmount = 10;

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
        public Tile[,]  GetTiles()                      { return            TILES; }
        public static String GetDefaultImage()          { return            DEFAULT_IMAGE; }
        public ImagePalette GetImagePalette()           { return            imagePalette; }
        public LAYER    GetCurrentLayer()               { return            currentLayer; }
        public void     SetCurrentLayer(LAYER l)        { currentLayer  =   l; }
        public void     SetMapName(String name)         { mapName       =   name; }
        public String   GetMapName()                    { return            mapName; }

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

        // Rebuilds the tile array based. Usually called after the map's rows and columns have changed.
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
        }
    }
}
