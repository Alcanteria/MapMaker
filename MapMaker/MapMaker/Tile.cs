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
        private ArrayList keys;

        /**************************************CONSTRUCTOR*/

        public Tile() 
        {
            keys = new ArrayList();
        }

        // Retrieves the list of keys this tile has.
        public ArrayList GetImageKeys()
        {
            return keys;
        }

        // Adds another image key to this tile's list.
        public void AddImageKey(String name)
        {
            GetImageKeys().Add(name);
        }
    }
}
