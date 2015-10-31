﻿using System;
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
        Bitmap testImage = new Bitmap(Image.FromFile("C:\\Users\\Nick\\Desktop\\DND\\tiles\\Torstan's100pxTiles\\Torstan's100pxTiles\\Background\\Textures\\Wood,horizontal.jpg"), 100, 100);

        // Load a jpg from local drive. (ON LAPTOP)
        //Bitmap testImage = new Bitmap(Image.FromFile("C:\\Users\\Nick\\Dropbox\\DIEDIE\\tiles\\Wood,horizontal.jpg"), 100, 100);

        // Get the dimensions of the primary monitor.
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        // The scale you want to draw the main window size to.
        private const float SCREEN_SCALE = .90f;

        // The size of the drawing surface as a percentage of the main window's size.
        private const float DRAWING_SURFACE_SCALE = .80f;

        // Map object.
        private Map testMap = new Map(10, 10);

        // Declare a version of the picture box to use to draw on to.
        private PictureBox drawSurface;

        // Pen for drawing the grid.
        Pen rectPen = new Pen(Color.Black);

        public mainForm()
        {
            InitializeComponent();

            // Link our draw surface to the picture box on the windows form.
            drawSurface = pictureBox;

            // Adjust the size of the main window based on the scale we've set above.
            this.Width  = (int)(screenWidth * SCREEN_SCALE);
            this.Height = (int)(screenHeight * SCREEN_SCALE);

            // Set the size of the drawing surface based on the main window's properties.
            drawSurface.Size = new Size((int)(Width * DRAWING_SURFACE_SCALE), (int)(Height * DRAWING_SURFACE_SCALE));

            // Set map properties.
            //testMap.SetIsGridOn(false);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the starting location of the main window.
            this.Location = new Point((int)(screenWidth * .05f), (int)(screenHeight * .05f));

            // Set the starting location of the drawing surface. This took a lot of trial and error, don't fuck with this.
            drawSurface.Location = new Point((Width - drawSurface.Width) - (int)(drawSurface.Width * .05f), Height - drawSurface.Height - (int)(drawSurface.Height * .1f));

            // Link the paint event of our draw surface to the windows event cycle
            drawSurface.Paint += new System.Windows.Forms.PaintEventHandler(this.drawSurface_Paint);

        }

        // This is where drawing is actually done.
        private void drawSurface_Paint(object sender, PaintEventArgs e)
        {
            // Good ol' graphics object.
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

            // Draw the grid if it is turned on.
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
