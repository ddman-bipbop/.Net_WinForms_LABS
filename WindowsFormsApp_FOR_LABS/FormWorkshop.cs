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
    public partial class FormWorkshop : Form
    {
        public Repair Repair { get; }
        public FormWorkshop(Repair repair)
        {
            InitializeComponent();
            Repair = repair;
            foreach (var item in Workshop.DCraftbanch)
            {
                var stanok = item.Value;
                comboBox1.Items.Add(stanok);
            }
            foreach (var item in Workshop.DNameRepair)
            {
                var room = item.Value;
                comboBox2.Items.Add(room);
            }
            comboBox1.SelectedItem = Repair.NameStanok;
            comboBox2.SelectedItem = Repair.NameRepair;
            dateTimePicker1.Value = Repair.DateStart;

        }

        private void FormWorkshop_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Repair.NameStanok = comboBox1.SelectedItem as Craftbanch;
            Repair.NameRepair = comboBox2.SelectedItem as NameRepair;
            Repair.DateStart = dateTimePicker1.Value;
        }
    }
}