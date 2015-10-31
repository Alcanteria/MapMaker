using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapMaker
{
    public partial class mainForm : Form
    {

        // Load a jpg from local drive. (ON DESKTOP)
        //Bitmap testImage = new Bitmap(Image.FromFile("C:\\Users\\Nick\\Desktop\\DND\\tiles\\Torstan's100pxTiles\\Torstan's100pxTiles\\Background\\Textures\\Wood,horizontal.jpg"), 100, 100);

        // Load a jpg from local drive. (ON LAPTOP)
        Bitmap testImage = new Bitmap(Image.FromFile("C:\\Users\\Nick\\Dropbox\\DIEDIE\\tiles\\Wood,horizontal.jpg"), 100, 100);

        // Location to draw our test image.
        PointF location = new PointF(0, 0);

        // Scaling to draw the image at.
        PointF scale = new PointF(50.0f, 50.0f);

        // Map object.
        private Map testMap = new Map(5, 5);

        // Declare a version of the picture box to use to draw on to.
        private PictureBox drawSurface;

        // Pen for draw rectangles.
        Pen rectPen = new Pen(Color.Black);

        public mainForm()
        {
            InitializeComponent();

            // Link our draw surface to the picture box on the windows form.
            drawSurface = pictureBox;

            // Set map properties.
            //testMap.SetIsGridOn(false);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Link the paint event of our draw surface to the windows event cycle
            drawSurface.Paint += new System.Windows.Forms.PaintEventHandler(this.drawSurface_Paint);

        }

        private void drawSurface_Paint(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();

            Graphics g = e.Graphics;

            // Draw the test tiles.
            for (int i = 0; i < testMap.GetColumns(); i++)
            {
                for (int j = 0; j < testMap.GetRows(); j++)
                {
                    g.DrawImage(testImage,
                                i * testMap.GetTileSize(),
                                j * testMap.GetTileSize(),
                                testMap.GetTileSize(),
                                testMap.GetTileSize());
                }
            }

            // Draw the grid, if it is turned on.
            if (testMap.IsGridOn())
            {
                for (int i = 0; i < testMap.GetColumns(); i++)
                {
                    for (int j = 0; j < testMap.GetRows(); j++)
                    {
                        g.DrawRectangle(rectPen,
                                        i * testMap.GetTileSize(),
                                        j * testMap.GetTileSize(),
                                        testMap.GetTileSize(),
                                        testMap.GetTileSize());
                    }
                }
            }
        }
    }
}
