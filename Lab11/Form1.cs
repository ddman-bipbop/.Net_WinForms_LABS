using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Lab11.Models;

namespace Lab11
{
    public partial class Form1 : Form
    {
        private readonly SqlConnection _connection;
        public Form1()
        {          
            InitializeComponent();
            _connection = new SqlConnection(@"Data Source=DESKTOP-EC5D0FL\SQLEXPRESS;Initial Catalog=DotNet;Integrated Security=True");

        }

   
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            var users = Kind_sport.List(_connection);
            listView1.Items.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                var listListViewItem = listView1.Items.Add(user.IdKind.ToString());
                listListViewItem.Tag = user;          
                listListViewItem.SubItems.Add(user.NameKind);
                listListViewItem.SubItems.Add(user.GroupKind);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KindSport_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormAddKindSport formUser = new FormAddKindSport
            {
                KindSport = new Kind_sport()
            };
            if (formUser.ShowDialog() == DialogResult.OK)
            {
                Kind_sport.Insert(_connection, formUser.KindSport);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormAddKindSport formUser = new FormAddKindSport
            {
                KindSport = (Kind_sport)listView1.SelectedItems[0].Tag
            };
            if (formUser.ShowDialog() == DialogResult.OK)
            {
                Kind_sport.Update(_connection, formUser.KindSport);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Kind_sport.Delete(_connection, ((Kind_sport)listView1.SelectedItems[0].Tag).IdKind);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}