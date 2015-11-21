using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapMaker
{
    /* This class handles saving/loading map files from local disk space. */
    static class MapIO
    {
        /********************************OUTPUT*/
        // Saves the supplied map to the supplied mapName path.
        public static void SaveMap(Map map)
        {
            // Create a string builder to store all of the information that will be written to the saved text file.
            StringBuilder builder = new StringBuilder();

            // Begin by writing a commented title to the text file.
            builder.AppendLine("// Map file for: " + Path.GetFileNameWithoutExtension(map.GetMapName()));

            // Dump everything into a text file.
            System.IO.File.WriteAllText(map.GetMapName(), builder.ToString());

            // Create a list to store all of the file names of every image in this map.
            List<String> images;

            MessageBox.Show("Map Saved.");
        }

        /* Checks if the supplied file name is already in the image list. If it isn't, add it to the list. */
        public static bool CheckForDuplicateImage(String image, List<String> list)
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
