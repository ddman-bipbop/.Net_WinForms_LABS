using ClassLibraryEmployees;
using WinFormsControlLibraryCompany;
using ClassLibraryEmployees.Serialization;

namespace program
{
    public partial class FormMain : Form
    {
        private readonly Company _company = Company.Instance;
        readonly FormTypesWork _formTypeWork = new FormTypesWork();
        readonly FormEmployees _formEmployees = new FormEmployees();
        readonly FormWork _formWork = new FormWork();


        public FormMain()
        {
            InitializeComponent();
            _company.EmployeesAdded += _company_EmployeesAdded;
            _company.TypeWorkAdded += _company_TypeWorkAdded;
            _company.WorkAdded += _company_WorkAdded;
            _company.EmployeesRemoved += _company_EmployeesRemoved;
            _company.TypeWorkRemoved += _company_TypeWorkRemoved;
            _company.WorkRemoved += _company_WorkRemoved;
        }

        private void _company_WorkRemoved(object sender, EventArgs e)
        {
            var work = sender as Work;
            for (int i = 0; i < tabPage3.Controls.Count; i++)
            {
                if ((tabPage3.Controls[i] as UserControlWork)?.Work == work)
                {
                    tabPage3.Controls.RemoveAt(i);
                    break;
                }
            }
        }

        private void _company_TypeWorkRemoved(object sender, EventArgs e)
        {
            var tWork = (string)sender;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (((TypeWork)listView2.Items[i].Tag).WorkInfo.NameWork == tWork)
                {
                    listView2.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _company_EmployeesRemoved(object sender, EventArgs e)
        {
            var emplId = (int)sender;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (((Employees)listView1.Items[i].Tag).EmployeesId == emplId)
                {
                    listView1.Items.RemoveAt(i);
                    break;
                }
            }
        }


        private void _company_WorkAdded(object sender, EventArgs e)
        {
            var work = sender as Work;
            if (work != null)
            {
                UserControlWork userControl = new UserControlWork(work)
                {
                    Dock = DockStyle.Top
                };
                tabPage3.Controls.Add(userControl);
            }
        }


        private void _company_TypeWorkAdded(object sender, EventArgs e)
        {
            var tWork = sender as TypeWork;
            if (tWork != null)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = tWork,
                    Text = tWork.ToString()
                };
                listView2.Items.Add(listViewItem);
            }
        }

        private void _company_EmployeesAdded(object sender, EventArgs e)
        {
            var empl = sender as Employees;
            if (empl != null)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = empl,
                    Text = empl.ToString()
                };
                listView1.Items.Add(listViewItem);
            }
        }


        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employees empl = new Employees();
            _formEmployees.Employees = empl;
            if (_formEmployees.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _company.AddEmpl(empl);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var empl = listView1.SelectedItems[0].Tag as Employees;
                _formEmployees.Employees = empl;
                if (_formEmployees.ShowDialog() == DialogResult.OK)
                {
                    listView1.SelectedItems[0].Text = _formEmployees.Employees.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с сотрудником");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var tWork = new TypeWork();
            _formTypeWork.TypeWork = tWork;
            if (_formTypeWork.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _company.AddTypeWork(tWork);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var tWork = listView2.SelectedItems[0].Tag as TypeWork;
                _formTypeWork.TypeWork = tWork;
                if (_formTypeWork.ShowDialog() == DialogResult.OK)
                {
                    listView2.SelectedItems[0].Text = _formTypeWork.TypeWork.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с видом работы");
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tabPage3.Controls.Count; i++)
                {
                    var userControl = tabPage3.Controls[i] as UserControlWork;
                    if (userControl != null)
                    {
                        if (userControl.Selected)
                        {
                            var work = userControl.Work;
                            _formWork.Work = work;
                            if (_formWork.ShowDialog() == DialogResult.OK)
                            {
                                userControl.Refresh();
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана запись о работе");
            }
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var work = new Work();
            _formWork.Work = work;
            if (_formWork.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _company.AddWork(work);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewEmployees_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var empl = listView1.SelectedItems[0].Tag as Employees;
                    if (empl != null)
                    {
                        _company.RemoveEmpl(empl.EmployeesId);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с сотрудником");
                }
            }
        }

        private void listViewTypeWork_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var tWork = listView2.SelectedItems[0].Tag as TypeWork;
                    if (tWork != null)
                    {
                        _company.RemoveTypeWork(tWork.WorkInfo.NameWork);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с видом работы");
                }
            }
        }


        private void saveXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogMain.Filter = "XML-файлы|*.xml|Все файлы|*.*";
            if (saveFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                CompanySerializable.Save(saveFileDialogMain.FileName, SerializeType.XML);
            }
        }

        private void saveJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogMain.Filter = "JSON-файлы|*.json|Все файлы|*.*";
            if (saveFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                CompanySerializable.Save(saveFileDialogMain.FileName, SerializeType.JSON);
            }
        }

        private void saveBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogMain.Filter = "Двоичные файлы|*.bin|Все файлы|*.*";
            if (saveFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                CompanySerializable.Save(saveFileDialogMain.FileName, SerializeType.Binary);
            }
        }

        private void loadXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogMain.Filter = "XML-файлы|*.xml|Все файлы|*.*";
            if (openFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                CompanySerializable.Load(openFileDialogMain.FileName, SerializeType.XML);

            }
        }

        private void loadJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogMain.Filter = "JSON-файлы|*.json|Все файлы|*.*";
            if (openFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                CompanySerializable.Load(openFileDialogMain.FileName, SerializeType.JSON);
            }
        }

        private void loadBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialogMain.Filter = "Двоичные файлы|*.bin|Все файлы|*.*";
            if (openFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                CompanySerializable.Load(openFileDialogMain.FileName, SerializeType.Binary);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

