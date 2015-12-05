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
    public partial class newMapDialog : Form
    {
        mainForm parentForm;

        public newMapDialog(mainForm main)
        {
            parentForm = main;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        /*************************************************Button Clicks*/

        // Create Map Button.
        private void createButton_Click(object sender, EventArgs e)
        {
            int x = (int)arrowSelectColumns.Value;
            int y = (int)arrowSelectRows.Value;

            parentForm.CreateNewMap(x, y);

            Hide();
        }

        // Cancel Button
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}
