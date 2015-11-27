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

            // Create a list to store all of the file names of every image in this map.
            List<String> images = new List<String>();

            /*********************************BUILD OUTPUT STRING*/

                // Begin by writing a commented title to the text file.
                builder.AppendLine("// Map file for: " + Path.GetFileNameWithoutExtension(map.GetMapName()));

                // Write map dimensions.
                builder.AppendLine("" + map.GetColumns());
                builder.AppendLine("" + map.GetRows());

                // Write tile information.
                for (int i = 0; i < map.GetColumns(); i++)
                {
                    for (int j = 0; j < map.GetRows(); j++)
                    {
                        // Write the tile coordinates.
                        builder.AppendLine("" + i);
                        builder.AppendLine("" + j);

                        /* Cycle through each layer of the tile and write down the image names. Goes in this layer order:
                                *   Floor
                                *   Wall
                                *   Decor
                         */
                        for (int x = 0; x < map.GetTiles()[i, j].GetImageKeys().Length; x++)
                            builder.AppendLine("" + map.GetTiles()[i,j].GetImageKeys()[x]);

                        // Store this tile's images into the library.
                        FileImages(map.GetTiles()[i, j], images);
                    }
                }

                // Let the map loader know it's tile to load images.
                builder.AppendLine("IMAGES");

                // Write down all of the images used in this map.
                foreach (String name in images)
                {
                    builder.AppendLine("" + name);
                }

                    // Dump everything into a text file.
                    System.IO.File.WriteAllText(map.GetMapName(), builder.ToString());

            MessageBox.Show("Map Saved.");
        }

        // Looks at the images used on the passed tile and files them into the image library if they aren't already.
        public static void FileImages(Tile tile, List<String> list)
        {
            for (int i = 0; i < tile.GetImageKeys().Length; i++)
            {
                if(!list.Contains(tile.GetImageKeys()[i]))
                    list.Add(tile.GetImageKeys()[i]);
            }
        }

        /********************************MORE INPUUUUUT*/
        // Returns a new map object based on the settings in the passed map path name.
        public static Map LoadMap(String map)
        {
            return null;
        }
    }
}
