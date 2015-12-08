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
        private String[] images;

        // Flag for an absent layer image. Only applies to non-floor layers.
        public static String NO_IMAGE = "[NO_IMAGE]";

        /**************************************CONSTRUCTOR*/

        public Tile() 
        {
            images = new String[3];
            for (int i = 0; i < images.Length; i++)
                images[i] = Tile.NO_IMAGE;
        }

        // Adds an image to the first layer of the tile. Used for the floor.
        public void AddTileFloor(String name)
        {
            GetImageKeys()[0] = name;
        }

        // Add an image to the second layer of the tile. Used for walls.
        public void AddTileWall(String name)
        {
            GetImageKeys()[1] = name;
        }

        // Adds an image to the third layer of the tile. Used for decor.
        public void AddTileDecor(String name)
        {
            GetImageKeys()[2] = name;
        }

        /***************************************ACCESSORS*/

        // Retrieves the list of keys this tile has.
        public  String[]    GetImageKeys()  {return     images;}

        // Returns the "bottom" or floor image for the tile.
        public  String      GetTileFloor()  {return     GetImageKeys()[0];}

        // Returns the "middle" or wall image for the tile.
        public  String      GetTileWall()   {return     GetImageKeys()[1]; }

        // Returns the "top" or decor image for the tile.
        public  String      GetTileDecor()  {return     GetImageKeys()[2];}

        // Sets the tile image key based on the passed layer.
        public void SetTileImage(Map.LAYER layer, String key)
        {
            GetImageKeys()[(int)layer] = key;
        }

        // Returns the tile image key based on the layer passed. Returns the default "no image" marker if none is specified.
        public String GetTileImageKey(Map.LAYER layer)
        {
            if (GetImageKeys()[(int)layer] != null || GetImageKeys()[(int)layer] != Tile.NO_IMAGE)
                return GetImageKeys()[(int)layer];
            else
                return Tile.NO_IMAGE;
        }

        // Checks if this tile image layer is emtpy.
        public Boolean IsTileLayerEmpty(Map.LAYER layer)
        {
            if (GetImageKeys()[(int)layer] == null || GetImageKeys()[(int)layer] == Tile.NO_IMAGE)
                return true;
            else
                return false;
        }

    }
}
