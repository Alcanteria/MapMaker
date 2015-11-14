using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    /* This class represents a single square on the map grid. It has its own image defined separately from
     other tiles on the map/grid. */
    class Tile
    {
        /* This list contains the key(s) of each image placed on this tile. The key is used to pull
         the appropriate image from the ImagePalette class. A tile can hold more than one key at a time. */
        private String[] keys;

        /**************************************CONSTRUCTOR*/

        public Tile() 
        {
            keys = new String[2];
        }

        // Adds an image to the first layer of the tile. Used for the floor.
        public void AddTileFloor(String name)
        {
            GetImageKeys()[0] = name;
        }

        // Adds an image to the second layer of the tile. Used for walls or decor.
        public void AddTileDecor(String name)
        {
            GetImageKeys()[1] = name;
        }

        /***************************************ACCESSORS*/

        // Retrieves the list of keys this tile has.
        public  String[]    GetImageKeys()  {return     keys;}

        // Returns the "bottom" or floor image for the tile.
        public  String      GetTileFloor()  {return     GetImageKeys()[0];}

        // Returns the "top" or decor image for the tile.
        public  String      GetTileDecor()  {return     GetImageKeys()[1];}

    }
}
