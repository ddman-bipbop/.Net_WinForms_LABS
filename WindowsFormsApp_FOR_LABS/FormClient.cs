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
    public partial class FormClient : Form
    {
        public Craftbanch stanok_ { get; }
        public FormClient(Craftbanch stanok)
        {
            InitializeComponent();
            stanok_ = stanok;
            textBox1.Text = stanok_.state_;
            textBox2.Text = stanok_.date_.ToString();
            textBox3.Text = stanok_.mark_;
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
            stanok_.state_ = textBox1.Text;      
            stanok_.date_= Convert.ToDateTime(textBox2.Text);
            stanok_.mark_ = textBox3.Text;   
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}