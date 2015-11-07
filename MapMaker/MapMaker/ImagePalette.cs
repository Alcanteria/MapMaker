using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MapMaker
{
    class ImagePalette
    {
        // This is the data structure that holds all images actually used in the map.
        private Dictionary<String, Bitmap> images;

        /**********************************CONSTRUCTOR*/
        public ImagePalette()
        {
            // Initialize the Dictionary.
            images = new Dictionary<String, Bitmap>();

            // Load the default image.
            LoadDefaultImage();
        }

        // Adds a new image to the library, provided it already isn't in there.
        public void AddNewImage(String name, Bitmap image)
        {
            if(!images.ContainsKey(name))
                images.Add(name, image);
        }

        /* Retrieves the specified image from the library. Pass the string key value. 
         Returns a default image if the passed image name is not found in the library. */
        public Bitmap GetImage(String name)
        {
            // Make sure a null argument wasn't passed, and see if "name" is in the library.
            if (name != null)
                if (images.ContainsKey(name))
                    return images[name];

            return images[Map.GetDefaultImage()];

        }

        // Loads the predermined default image file.
        public void LoadDefaultImage()
        {
            try
            {
                // Load a jpg from local drive. (ON LAPTOP)
                Bitmap defaultImage = new Bitmap(Image.FromFile("C:\\Users\\Nick\\Desktop\\" + Map.GetDefaultImage()), 100, 100);

                // Add the key to the default image to the palette.
                AddNewImage(Map.GetDefaultImage(), defaultImage);

            }
            catch (Exception e)
            {
                MessageBox.Show("Default image could not be loaded.");
                Console.Write(e.ToString());
            }
        }
    }
}
