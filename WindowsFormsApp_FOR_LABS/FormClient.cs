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
    public partial class FormClient : Form
    {
        public Craftbanch Stanok { get; }
        public FormClient(Craftbanch stanok)
        {
            InitializeComponent();
            Stanok = stanok;
            textBox1.Text = Stanok.State;
            dateTimePicker1.Text = Stanok.Date.ToString();
            textBox3.Text = Stanok.Mark;
        }


        private void FormClient_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stanok.State = textBox1.Text;
            //Stanok.Date= Convert.ToDateTime(textBox2.Text);
            Stanok.Date = Convert.ToDateTime(dateTimePicker1.Text);
            Stanok.Mark = textBox3.Text;   
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}