using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryEmployees;

namespace program
{
    public partial class FormEmployees : Form
    {
        private Employees _employees;

        public Employees Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                textBox1.Text = Employees.FirstName;
                textBox2.Text = Employees.LastName;
                textBox3.Text = Employees.MiddleName;
                numericUpDown1.Value = Employees.Salary;
            }
        }

        public FormEmployees()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _employees.FirstName = textBox1.Text;
            _employees.LastName = textBox2.Text;
            _employees.MiddleName = textBox3.Text;
            _employees.Salary = (int)numericUpDown1.Value;
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
