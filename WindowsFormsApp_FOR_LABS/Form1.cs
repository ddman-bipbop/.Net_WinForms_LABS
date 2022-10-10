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
    public partial class Form1 : Form
    {
        private Stanok stanok_;
        private NameRepair nameRepair_;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stanok_ = new Stanok();
            FormClient formClient = new FormClient(stanok_);
            if (formClient.ShowDialog() == DialogResult.OK)
            {
                stanok_ = formClient.stanok_;
            }
            
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClient formClient = new FormClient(stanok_);
            if (formClient.ShowDialog() == DialogResult.OK)
            {
                stanok_ = formClient.stanok_;
            }

        }
    }
}