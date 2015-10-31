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
        private Point MAP_ROOT = new Point(0, 0);

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
        public void     SetMapRoot(int x, int y)        { MAP_ROOT.X = x; MAP_ROOT.Y = y; }
        public Point    GetMapRoot()                    { return MAP_ROOT; }

    }
}
