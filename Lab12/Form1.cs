using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form1 : Form
    {
        private Dictionary<int, string> positions_ = new Dictionary<int, string>();
        public Form1()
        {
            InitializeComponent();
        }
        private void updateKindSportList()
        {
            positions_.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    positions_.Add((int)row.Cells[0].Value, (string)row.Cells[1].Value);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dotNetDataSet.Sport_club". При необходимости она может быть перемещена или удалена.
            this.sport_clubTableAdapter.Fill(this.dotNetDataSet.Sport_club);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dotNetDataSet.Kind_sport". При необходимости она может быть перемещена или удалена.
            this.kind_sportTableAdapter.Fill(this.dotNetDataSet.Kind_sport);
            updateKindSportList();

        }

        private void kindsportBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kindsportBindingSource.EndEdit();
            this.kind_sportTableAdapter.Update(this.dotNetDataSet.Kind_sport);
            updateKindSportList();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sportclubBindingSource.EndEdit();
            this.sport_clubTableAdapter.Update(this.dotNetDataSet.Sport_club);
        }

        private void SportClubPage1_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView drw = (DataRowView)sportclubBindingSource.Current;
            DotNetDataSet.Sport_clubRow ur = (DotNetDataSet.Sport_clubRow)(drw.Row);
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                toolStripStatusLabel1.Text = "Фотография загружена успешно";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView drw = (DataRowView)sportclubBindingSource.Current;
            DotNetDataSet.Sport_clubRow ur = (DotNetDataSet.Sport_clubRow)(drw.Row);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image != null)
                {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
                    pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fs.Close();
                    toolStripStatusLabel1.Text = "Фотография успешно сохранена";
                }
            }
        }

        private void propToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyForm pForm = new PropertyForm(pictureBox1);
            if (pForm.ShowDialog() == DialogResult.OK) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRowView drw = (DataRowView)sportclubBindingSource.Current;
            DotNetDataSet.Sport_clubRow ur = (DotNetDataSet.Sport_clubRow)(drw.Row);

            this.Text = ur.id_club.ToString();
            PrintForm printForm = new PrintForm(textBox1, textBox2, positions_[ur.id_kind], dateTimePicker1, pictureBox1);
            if (printForm.ShowDialog() == DialogResult.OK) { }
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.sport_clubTableAdapter.Fill(this.dotNetDataSet.Sport_club);
        }
    }
}
