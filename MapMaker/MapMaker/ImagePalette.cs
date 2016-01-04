﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace MapMaker
{
    class ImagePalette
    {
        // This is the data structure that holds all images actually used in the map.
        private Dictionary<String, Bitmap> images;

        // Width and height all images are scaled to in pixels.
        public static int IMAGE_SIZE = 200;

        // Contains the current image to be painted onto the map.
        private String currentImage;

        /**********************************CONSTRUCTOR*/
        public ImagePalette()
        {
            // Initialize the Dictionary.
            images = new Dictionary<String, Bitmap>();

        }

        // Adds a new image to the library, provided it already isn't in there.
        public void AddNewImage(String name, Bitmap image)
        {
            if (!images.ContainsKey(name))
            {
                images.Add(name, image);
                Console.WriteLine(name + " added to image library.");
            }
            else
                Console.WriteLine(name + " already in image library.");

            PrintImageList();
        }

        // Loads the predermined default image file.
        public void LoadDefaultImage(Image image)
        {
            try
            {
                // Load the default image into a properly sized copy
                Bitmap newImage = new Bitmap(image, IMAGE_SIZE, IMAGE_SIZE);

                Bitmap defaultImage = (Bitmap)newImage.Clone();

                // Add the key to the default image to the palette.
                AddNewImage(Map.GetDefaultImage(), defaultImage);

            }
            catch (Exception e)
            {
                MessageBox.Show("Default image could not be loaded.");
                Console.Write(e.ToString());
            }
        }

        /****************************************************ACCESSORS*/

        public  void    SetCurrentImage(String image)   { currentImage  =   image; }
        public  String  GetCurrentImage()               { return            currentImage; }

        /* Retrieves the specified image from the library. Pass the string key value. 
         Returns a default image if the passed image name is not found in the library. */
        public Bitmap GetImage(String name)
        {
            if (name != null)
                if (images.ContainsKey(name))
                    return images[name];

            return images[Map.GetDefaultImage()];
        }

        // Prints out a list of loaded images to the console.
        public void PrintImageList()
        {
            foreach (KeyValuePair<String, Bitmap> entry in images)
            {
                Console.WriteLine("Image Library+++++++++");
                Console.WriteLine(entry.Key);
            }
        }
    }
}
