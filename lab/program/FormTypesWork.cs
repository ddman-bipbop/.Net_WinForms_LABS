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
    public partial class FormTypesWork : Form
    {
        private TypeWork _typeWork;
        public TypeWork TypeWork
        {
            get
            {
                return _typeWork;
            }
            set
            {
                _typeWork = value;
                textBox1.Text = _typeWork.WorkInfo.NameWork;
                textBox2.Text = _typeWork.WorkInfo.Info;
                numericUpDown1.Value = TypeWork.WorkInfo.Time;
                numericUpDown2.Value = _typeWork.PayByDay;
            }
        }

        public FormTypesWork()
        {
            InitializeComponent();
        }

        private void FormTypesWork_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _typeWork.WorkInfo.NameWork = textBox1.Text;
            _typeWork.WorkInfo.Info = textBox2.Text;
            _typeWork.PayByDay = (int)numericUpDown2.Value;
            _typeWork.WorkInfo.Time = (int)numericUpDown1.Value;

            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
