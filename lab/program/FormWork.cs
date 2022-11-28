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
    public partial class FormWork : Form
    {

        private readonly Company _company = Company.Instance;
        private Work _work;

        public Work Work
        {
            get { return _work; }
            set
            {
                _work = value;
                comboBox1.SelectedItem = _work.Employees;
                comboBox2.SelectedItem = _work.TypeWork;
                dateTimePicker1.Value = _work.StartDate;
                dateTimePicker2.Value = _work.EndDate;
            }
        }

        public FormWork()
        {
            InitializeComponent();
            _company.EmployeesAdded += _company_EmployeesAdded;
            _company.EmployeesRemoved += _company_EmployeesRemoved;
            _company.TypeWorkAdded += _company_TypeWorkAdded;
            _company.TypeWorkRemoved += _company_TypeWorkRemoved;
            foreach (var empl in _company.Employeess)
            {
                comboBox1.Items.Add(empl);
            }
            foreach (var tWork in _company.TypeWorks)
            {
                comboBox2.Items.Add(tWork);
            }
        }

        private void _company_TypeWorkRemoved(object sender, EventArgs e)
        {
            string key = (string)sender;
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                var tWork = comboBox2.Items[i] as TypeWork;
                if (tWork?.WorkInfo.NameWork == key)
                {
                    comboBox2.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _company_TypeWorkAdded(object sender, EventArgs e)
        {
            comboBox2.Items.Add(sender);
        }

        private void _company_EmployeesRemoved(object sender, EventArgs e)
        {
            int key = (int)sender;
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                var empl = comboBox1.Items[i] as Employees;
                if (empl?.EmployeesId == key)
                {
                    comboBox1.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _company_EmployeesAdded(object sender, EventArgs e)
        {
            comboBox1.Items.Add(sender);
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _work.Employees = comboBox1.SelectedItem as Employees;
            _work.TypeWork = comboBox2.SelectedItem as TypeWork;
            _work.StartDate = dateTimePicker1.Value;
            _work.EndDate = dateTimePicker2.Value;
            this.Close();
        }
    }
}
