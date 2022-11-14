﻿using System;
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
    public partial class UserControl1 : UserControl
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
                            if (!(control is UserControl1)) continue;
                            var userControlSettlement = control as UserControl1;
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
        public UserControl1(Repair settlement)
        {
            InitializeComponent();
            Settlement = settlement;
        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            textBox1.Text = Settlement.NameStanok.ToString();
            textBox2.Text = Settlement.NameRepair.Name.ToString();

            dateTimePicker1.Text = Settlement.DateStart.ToString();

            BackColor = _selected ? Color.CornflowerBlue : DefaultBackColor;

        }
        private void UserControl1_Click(object sender, EventArgs e)
        {
            Selected = true;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settlement.NameStanok.Mark;
            textBox2.Text = Settlement.NameRepair.Name.ToString();

            dateTimePicker1.Text = Settlement.DateStart.ToString();
            BackColor = _selected ? Color.CornflowerBlue : DefaultBackColor;
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserControl1_MouseClick(object sender, MouseEventArgs e)
        {
            Selected = true;
        }

        private void UserControl1_Click_1(object sender, EventArgs e)
        {
            Selected = true;
        }

        private void UserControl1_Paint_1(object sender, PaintEventArgs e)
        {
            BackColor = _selected ? Color.CornflowerBlue : DefaultBackColor;
        }
    }
}
