using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab4;

namespace WindowsFormsApp_FOR_LABS
{
    public partial class FormRepair : Form
    {
        public NameRepair nameRepair_ { get; }
        public FormRepair(NameRepair nameRepair)
        {
            InitializeComponent();
            nameRepair_ = nameRepair;
            textBox1.Text = nameRepair_.Name;
            textBox2.Text = nameRepair_.Duration.ToString();
            textBox3.Text = nameRepair_.Price.ToString();
            textBox4.Text = nameRepair_.Commet;
        }

        private void FormRepair_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }    
        private void button1_Click(object sender, EventArgs e)
        {
            nameRepair_.Name = textBox1.Text;
            nameRepair_.Duration = Convert.ToInt16(textBox2.Text);
            nameRepair_.Price = Convert.ToDouble(textBox3.Text);
            nameRepair_.Commet = textBox4.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
