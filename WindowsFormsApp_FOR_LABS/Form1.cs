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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text += " " + this.numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox2.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double d1 = Convert.ToDouble(textBox4.Text);
            double d2 = Convert.ToDouble(textBox5.Text);
            double d3 = d1 + d2;
            textBox6.Text = d3.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double d1 = Convert.ToDouble(textBox4.Text);
            double d2 = Convert.ToDouble(textBox5.Text);
            double d3 = d1 - d2;
            textBox6.Text = d3.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double d1 = Convert.ToDouble(textBox4.Text);
            double d2 = Convert.ToDouble(textBox5.Text);
            double d3 = d1 * d2;
            textBox6.Text = d3.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double d1 = Convert.ToDouble(textBox4.Text);
            double d2 = Convert.ToDouble(textBox5.Text);
            double d3 = d1 / d2;
            textBox6.Text = d3.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double d;
            if (double.TryParse(textBox7.Text, out d))
            {
                //Переменная d хранит число, если преобразование удалось

                comboBox2.Items.Add(d.ToString());
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}