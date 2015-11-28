﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace MapMaker
{
    /* This class handles saving/loading map files from local disk space. */
    static class MapIO
    {
        /**********************SPECIAL CHARACTERS*/
        public static String COMMENT        = @"//";
        public static String IMAGE_LOAD     = "<IMAGES>";
        public static String IMAGE_CLOSE    = "<IMAGES_END>";
        public static String MAP_LOAD       = "<MAP>";
        public static String MAP_CLOSE      = "<MAP_END>";
        public static String CLOSE_FILE     = "<END>";

        /********************************OUTPUT*/
        // Saves the supplied map to the supplied mapName path.
        public static void SaveMap(Map map)
        {
            // Create a string builder to store all of the map information.
            StringBuilder guts = new StringBuilder();

            // Create a string builder to store all of the images to load for this map.
            StringBuilder imageNames = new StringBuilder();

            // Create a list to store all of the file names of every image in this map.
            List<String> images = new List<String>();

            /*********************************BUILD OUTPUT STRING*/

                // Begin by writing a commented title to the text file.
                imageNames.AppendLine(MapIO.COMMENT + " Map file for: " + Path.GetFileNameWithoutExtension(map.GetMapName()));
                imageNames.AppendLine();

                // Let the map loader know it's tile to load images.
                imageNames.AppendLine(MapIO.IMAGE_LOAD);

                // Let the map loader know it's time to load the map information.
                guts.AppendLine();
                guts.AppendLine(MapIO.MAP_LOAD);

                // Write map dimensions.
                guts.AppendLine("" + map.GetColumns());
                guts.AppendLine("" + map.GetRows());

                // Write tile information.
                for (int i = 0; i < map.GetColumns(); i++)
                {
                    for (int j = 0; j < map.GetRows(); j++)
                    {
                        // Write the tile coordinates.
                        guts.AppendLine("" + i);
                        guts.AppendLine("" + j);

                        /* Cycle through each layer of the tile and write down the image names. Goes in this layer order:
                                *   Floor
                                *   Wall
                                *   Decor
                         */
                        for (int x = 0; x < map.GetTiles()[i, j].GetImageKeys().Length; x++)
                            guts.AppendLine("" + map.GetTiles()[i,j].GetImageKeys()[x]);

                        // Store this tile's images into the library.
                        FileImages(map.GetTiles()[i, j], images);
                    }
                }

                // Mark the end of the map load.
                guts.AppendLine(MapIO.MAP_CLOSE);

                // Mark the end of the save file.
                guts.AppendLine(MapIO.CLOSE_FILE);

                // Write down all of the images used in this map.
                foreach (String name in images)
                {
                    if(name != Tile.NO_IMAGE)
                        imageNames.AppendLine("" + name);
                }

                // Terminate the image load sequence.
                imageNames.AppendLine(MapIO.IMAGE_CLOSE);

                imageNames.Append(guts.ToString());

                // Dump everything into a text file.
                System.IO.File.WriteAllText(map.GetMapName(), imageNames.ToString());

            MessageBox.Show("Map Saved.");
        }

        // Looks at the images used on the passed tile and files them into the image library if they aren't already.
        public static void FileImages(Tile tile, List<String> list)
        {
            for (int i = 0; i < tile.GetImageKeys().Length; i++)
            {
                if(!list.Contains(tile.GetImageKeys()[i]) && tile.GetImageKeys()[i] != null)
                    list.Add(tile.GetImageKeys()[i]);
            }
        }

        /********************************MORE INPUUUUUT*/
        // Returns a new map object based on the settings in the passed map path name.
        public static Map LoadMap(String map)
        {
            // Create a new map to build from a local file.
            Map newMap = new Map(0, 0);

            // Placeholder for the line being currently ready from file.
            String line;

            // Create a file from the supplied map name/file path.
            System.IO.StreamReader file = new System.IO.StreamReader(map);

            // Go through each line of the map file and process each command appropriately.
            while ((line = file.ReadLine()) != null)
            {
                /*************************************FILE END*/
                if (line.StartsWith(MapIO.CLOSE_FILE))
                    break;

                /*************************************COMMENTS*/
                if (line.StartsWith(MapIO.COMMENT))
                    continue;

                /************************************LOAD IMAGES*/
                if(line.StartsWith(MapIO.IMAGE_LOAD))
                {
                    // Cycle to the next line
                    line = file.ReadLine();

                    // Keep loading each line as an image until you reach the end.
                    while (line != MapIO.IMAGE_CLOSE)
                    {
                        try
                        {
                            Bitmap image = new Bitmap(Image.FromFile(line), ImagePalette.IMAGE_SIZE, ImagePalette.IMAGE_SIZE);
                            newMap.GetImagePalette().AddNewImage(line, image);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Could not load image: " + line);
                            Console.WriteLine("" + e.ToString());
                        }

                        // Make sure you cycle to the next line in the file before you restart the loop.
                        line = file.ReadLine();
                    }
                    continue;
                }

                /************************************LOAD MAP*/
                if (line.StartsWith(MapIO.MAP_LOAD))
                {
                    // Cycle to the next line, which is the beginning of the map attributes.
                    line = file.ReadLine();

                    // Get the map dimentions from the file into local variables.
                    int colomns = Int32.Parse(line);
                         line = file.ReadLine();
                    int rows = Int32.Parse(line);
                          line = file.ReadLine();

                    // Set the map dimentions.
                    newMap.SetColumns(colomns);
                    newMap.SetRows(rows);
                    newMap.RebuildMap();

                    // Loop through every tile and set its images.
                    while (line != MapIO.MAP_CLOSE)
                    {
                        for (int i = 0; i < newMap.GetColumns(); i++)
                        {
                            for (int j = 0; j < newMap.GetRows(); j++)
                            {
                                // Read the tile coordinates and advance the line reader as necessary.
                                int x = Int32.Parse(line);
                                    line = file.ReadLine();
                                int y = Int32.Parse(line);
                                    line = file.ReadLine();

                                    // Loop through each layer of the tile and set its image.
                                    for (int n = 0; n < Map.NUMBER_OF_LAYERS; n++)
                                    {
                                        newMap.GetTiles()[x, y].SetTileImage((Map.LAYER)n, line);
                                        line = file.ReadLine();
                                    }
                            }
                        }
                    }
                    continue;
                }

            }

            // Shut the door.
            file.Close();

            return newMap;
        }
    }
}
