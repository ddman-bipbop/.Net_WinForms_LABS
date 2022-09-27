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
            comboBox2.Items.Clear();
            for (int i = 0; i < textBox7.Lines.Length; i++)
            {
                if (double.TryParse(textBox7.Lines[i], out double numvalue))
                    comboBox2.Items.Add(textBox7.Lines[i]);
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox_tab5.Clear();
            double eps = ((double)numericUpDown2.Value);
            double x = 1;
            double summary = 0;
            double element = 0;
            do
            {
                element = 1 / x;
                textBox_tab5.Text += summary.ToString() + Environment.NewLine;
                summary += element;
                x++;

            } while (element > eps);

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_tab5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
            string[] text1 = textBox8.Lines;
            for (int i = text1.Length-1; i > 0 ; i--)
            {
                if (!(double.TryParse(text1[i], out double num)))
                {
                    textBox9.Text += text1[i] + Environment.NewLine;
                }
            }
        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_tab7_a_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_tab7_result_Click(object sender, EventArgs e)
        {
            textBox_tab7_Res.Clear();
            bool text1 = decimal.TryParse(textBox_tab7_a.Text, out decimal a);
            bool text2 = decimal.TryParse(textBox_tab7_b.Text, out decimal b);
            bool text3 = decimal.TryParse(textBox_tab7_h.Text, out decimal h);

            if (!(text1 && text2 && text3) || (a > b || h < 0 || h > Math.Abs(b - a)))
            {
                textBox_tab7_Res.Text = "Переменные введены некорректно! Читать условие...";
                return;
            }
            double f;
            for (decimal i = a; i <= b; i += h)
            {
                f = Math.Sin((double)i) / (Math.Abs((double)i) + 1);
                textBox_tab7_Res.Text += " x= " + i.ToString() + "; f(x)= " + f.ToString() + Environment.NewLine;
            }
        }
    }
}