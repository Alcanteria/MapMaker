﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
            private int scrollAmount = 5;

        /***************************************IMAGE PALETTE*/

            // The object that stores all images used in the map.
            private ImagePalette IMAGE_PALETTE = new ImagePalette();

            // The default image to use in the event that a an image is missing.
            private static String DEFAULT_IMAGE =("Wood,horizontal.jpg");

        /*******************************************TILES*/

            // The array of tiles in the map.
            private Tile[,] TILES;

        /**************************************CONSTRUCTOR*/

        // Creates a map with the supplied dimensions (in tiles, not pixels).
        public Map(int columns, int rows)
        {
            // Set up the map dimensions
            SetColumns(columns);
            SetRows(rows);
            SetIsGridOn(true);

            // Initialize the Tile array based on the above dimensions.
            TILES = new Tile[columns, rows];

            for (int i = 0; i < columns; i++)
                for (int j = 0; j < rows; j++)
                    TILES[i, j] = new Tile();
        }

        /**************************************ACCESSORS*/

        public void     SetColumns(int numberOfColumns) { columns       =   numberOfColumns; }
        public int      GetColumns()                    { return            columns; }
        public void     SetRows(int numberOfRows)       { rows          =   numberOfRows; }
        public int      GetRows()                       { return            rows; }
        public void     SetTileSize(int sizeOfTile)     { tileSize      =   sizeOfTile; }
        public int      GetTileSize()                   { return            tileSize; }
        public void     SetIsGridOn(bool isTheGridOn)   { isGridOn      =   isTheGridOn; }
        public bool     IsGridOn()                      { return            isGridOn; }
        public void     SetMapRootX(int x)              { mapRootX      =   x; }
        public void     SetMapRootY(int y)              { mapRootY      =   y; }
        public int      GetMapRootX()                   { return            mapRootX; }
        public int      GetMapRootY()                   { return            mapRootY; }
        public void     SetScrollAmount(int amount)     { scrollAmount  =   amount; }
        public int      GetScrollAmount()               { return            scrollAmount; }
        public Tile[,]  GetTiles()                      { return            TILES; }
        public static String GetDefaultImage()          { return            DEFAULT_IMAGE; }

        // Retreives the image for the tile at the specified index.
        public Bitmap GetTileImage(int x, int y)
        {
            return IMAGE_PALETTE.GetImage(TILES[x, y].GetTileFloor());
        }

    }
}
