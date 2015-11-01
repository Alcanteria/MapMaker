using System;
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

        /**************************************CONSTRUCTOR*/

        // Minimal constructor. Only sets columns and rows. Grid is on by default.
        public Map(int columns, int rows)
        {
            SetColumns(columns);
            SetRows(rows);
            SetIsGridOn(true);
        }

        /**************************************ACCESSORS*/

        public void     SetColumns(int numberOfColumns) { columns = numberOfColumns; }
        public int      GetColumns()                    { return columns; }
        public void     SetRows(int numberOfRows)       { rows = numberOfRows; }
        public int      GetRows()                       { return rows; }
        public void     SetTileSize(int sizeOfTile)     { tileSize = sizeOfTile; }
        public int      GetTileSize()                   { return tileSize; }
        public void     SetIsGridOn(bool isTheGridOn)   { isGridOn = isTheGridOn; }
        public bool     IsGridOn()                      { return isGridOn; }
        public void     SetMapRootX(int x)              { mapRootX = x; }
        public void     SetMapRootY(int y)              { mapRootY = y; }
        public int      GetMapRootX()                   { return mapRootX; }
        public int      GetMapRootY()                   { return mapRootY; }
        public void     SetScrollAmount(int amount)     { scrollAmount = amount; }
        public int      GetScrollAmount()               { return scrollAmount; }

    }
}
