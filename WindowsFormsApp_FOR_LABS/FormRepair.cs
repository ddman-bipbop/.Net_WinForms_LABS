using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab5;

namespace WindowsFormsApp_FOR_LABS
{
    public partial class FormRepair : Form
    {
        public NameRepair NameRepair { get; }
        public FormRepair(NameRepair nameRepair)
        {
            InitializeComponent();
            NameRepair = nameRepair;
            comboBox1.Items.Add(CategoryNameRepair.Current);
            comboBox1.Items.Add(CategoryNameRepair.Midle);
            comboBox1.Items.Add(CategoryNameRepair.Capital);     
            comboBox1.SelectedItem = NameRepair.Name;

            numericUpDown1.Value = NameRepair.Duration;
            numericUpDown2.Value = (decimal)NameRepair.Price;
            textBox4.Text = NameRepair.Commet;
        }

        private void FormRepair_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }    
        private void button1_Click(object sender, EventArgs e)
        {
            NameRepair.Name = (CategoryNameRepair)comboBox1.SelectedItem;
            NameRepair.Duration = ((int)numericUpDown1.Value);
            NameRepair.Price = (double)numericUpDown2.Value;
            NameRepair.Commet = textBox4.Text;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
