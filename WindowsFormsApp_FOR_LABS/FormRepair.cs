using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_FOR_LABS
{
    public partial class FormRepair : Form
    {
        private NameRepair _room;
        public NameRepair Room
        {
            get
            {
                return _room;
            }
            set
            {
                _room = value;

                comboBox1.SelectedItem = _room.Name;

                numericUpDown1.Value = _room.Duration;
                numericUpDown2.Value = (decimal)_room.Price;
                textBox4.Text = _room.Commet;
            }
        }
  

        public FormRepair()
        {        
            InitializeComponent();
            comboBox1.Items.Add(CategoryNameRepair.Current);
            comboBox1.Items.Add(CategoryNameRepair.Midle);
            comboBox1.Items.Add(CategoryNameRepair.Capital);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _room.Name = (CategoryNameRepair)comboBox1.SelectedItem;
            _room.Duration = ((int)numericUpDown1.Value);
            _room.Price = (double)numericUpDown2.Value;
            _room.Commet = textBox4.Text;
        }

        private void FormRepair_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
