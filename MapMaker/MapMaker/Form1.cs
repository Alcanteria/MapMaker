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

        // Load a jpg from local drive.
        Bitmap testImage = new Bitmap(Image.FromFile("C:\\Users\\Nick\\Desktop\\DND\\tiles\\Torstan's100pxTiles\\Torstan's100pxTiles\\Background\\Textures\\Wood,horizontal.jpg"), 100, 100);

        public mainForm()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = testImage;
        }
    }
}
