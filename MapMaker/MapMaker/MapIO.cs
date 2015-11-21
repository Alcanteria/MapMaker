using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    /* This class handles saving/loading map files from local disk space. */
    static class MapIO
    {
        /********************************OUTPUT*/
        // Saves the supplied map to the supplied mapName path.
        public static void SaveMap(Map map, String mapName)
        {
            // Create a list to store all of the file names of every image in this map.
            List<String> images;
        }

        /* Checks if the supplied file name is already in the image list. If it isn't, add it to the list. */
        public Boolean CheckForDuplicateImage(String image, List<String> list)
        {
            if (list.Contains(image))
                return true;
            else
                list.Add(image);

            return false;
        }

        /********************************MORE INPUUUUUT*/
        // Returns a new map object based on the settings in the passed map path name.
        public static Map LoadMap(String map)
        {
            return null;
        }
    }
}
