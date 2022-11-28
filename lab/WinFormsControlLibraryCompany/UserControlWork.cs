using ClassLibraryEmployees;

namespace WinFormsControlLibraryCompany
{
    public partial class UserControlWork : UserControl
    {
        private readonly Company _company = Company.Instance;
        public Work Work { get; }
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
                            if (!(control is UserControlWork)) continue;
                            var userControlWork = control as UserControlWork;
                            if (userControlWork != this)
                            {
                                userControlWork.Selected = false;
                            }
                        }
                    }
                }
                _selected = value;
                Refresh();
            }
        }

        public UserControlWork(Work work)
        {
            InitializeComponent();
            Work = work;
        }

        private void UserControlWork_Paint(object sender, PaintEventArgs e)
        {
            textBox1.Text = $@"{Work.Employees.LastName} {Work.Employees.FirstName[0]}.{Work.Employees.MiddleName[0]}.";
            textBox2.Text = Work.TypeWork.WorkInfo.NameWork;
            textBox3.Text = $@"С {Work.StartDate:dd MMMM yyyy} по {Work.EndDate:dd MMMM yyyy}";
            if (Work.EndDate < DateTime.Today)
            {
                textBox3.BackColor = Color.Green;
            }
            else
            {
                textBox3.BackColor = Work.StartDate < DateTime.Today ? Color.Yellow : Color.Red;
            }
            BackColor = _selected ? Color.CornflowerBlue : DefaultBackColor;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _company.RemoveWork(Work);
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана запись о работе");
            }
        }

        private void UserControlWork_Click(object sender, EventArgs e)
        {
            Selected = true;
        }


    }
}