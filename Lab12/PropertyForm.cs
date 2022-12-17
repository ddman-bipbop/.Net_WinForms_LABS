using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12
{
    public partial class PropertyForm : Form
    {
        public PropertyForm(PictureBox photoPictureBox)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = photoPictureBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
