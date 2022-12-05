using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab11.Models;

namespace Lab11
{
    public partial class FormAddKindSport : Form
    {
        private Kind_sport _kindSport;
        public Kind_sport KindSport 
        {
            get { return _kindSport; }
            set 
            { 
                _kindSport = value;
                textBox1.Text = _kindSport.NameKind;
                textBox2.Text = _kindSport.GroupKind;

            }
        }
        public FormAddKindSport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _kindSport.NameKind = textBox1.Text;
            _kindSport.GroupKind = textBox2.Text;   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
