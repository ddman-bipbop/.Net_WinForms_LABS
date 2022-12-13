using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab11.DataSet1TableAdapters;
using Lab11.Models;

namespace Lab11
{
    public partial class FormAddSportClub : Form
    {
        private Sport_club _sportClub;

        public Sport_club SportClub { 
            get { return _sportClub; }
            set { 
                _sportClub = value;
                numericUpDown1.Value = _sportClub.IdKind;
                textBox2.Text = _sportClub.NameClub;
                textBox3.Text = _sportClub.TextClub;
                dateTimePicker1.Value = _sportClub.CreateDateClub;
            }
        }
        public FormAddSportClub()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _sportClub.IdKind = ((int)numericUpDown1.Value);
            _sportClub.NameClub = textBox2.Text;
            _sportClub.TextClub = textBox3.Text;
            _sportClub.CreateDateClub = dateTimePicker1.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
