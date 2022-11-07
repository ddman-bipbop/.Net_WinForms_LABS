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
    public partial class FormClient : Form
    {
        
        private Craftbanch _client;

        public Craftbanch Client
        {
            get { return _client; }
            set
            {
                _client = value;            
                textBox1.Text = Client.State;
                dateTimePicker1.Text = Client.Date.ToString();
                textBox3.Text = Client.Mark;
            }
        }


        //public Craftbanch Stanok { get; }
        public FormClient()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            _client.State = textBox1.Text;
            _client.Date = Convert.ToDateTime(dateTimePicker1.Text);
            _client.Mark = textBox3.Text;   
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
    }
}