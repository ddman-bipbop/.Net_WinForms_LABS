using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_FOR_LABS;


namespace WindowsFormsControlLibraryCraftbanch
{
    public partial class UserControlSettlement: UserControl
    {
        private readonly Workshop _hotel = Workshop.Instance;
        public Repair Settlement { get; }
        private bool _selected;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                if (value)
                {
                    var controls = Parent?.Controls;
                    if (controls != null)
                    {
                        foreach (var control in controls)
                        {
                            if (!(control is UserControlSettlement)) continue;
                            var userControlSettlement = control as UserControlSettlement;
                            if (userControlSettlement != this)
                            {
                                userControlSettlement.Selected = false;
                            }
                        }
                    }
                }
                _selected = value;
                Refresh();
            }
        }
        public UserControlSettlement(Repair settlement)
        {
            InitializeComponent();
            Settlement = settlement;
        }
        private void UserControlSettlement_Paint(object sender, PaintEventArgs e)
        {
            textBox1.Text = $@"{Settlement.NameStanok}.";
            textBox2.Text = Settlement.NameRepair.Name.ToString();

            dateTimePicker1.Text = $@" {Settlement.DateStart}";
        
            BackColor = _selected ? Color.CornflowerBlue : DefaultBackColor;

        }
        private void UserControlSettlement_Click(object sender, EventArgs e)
        {
            Selected = true;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _hotel.RemoveSettlement(Settlement);
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана запись о поселении");
            }
        }


        private void UserControlSettlement_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
