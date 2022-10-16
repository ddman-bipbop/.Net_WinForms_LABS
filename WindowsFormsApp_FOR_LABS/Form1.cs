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
    public partial class Form1 : Form
    {
        private Craftbanch stanok_;
        private NameRepair nameRepair_;
        private Repair repair_;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }   

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }   

        private void Form1_Load_2(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {       
            var stanok = new Craftbanch();
            FormClient formClient = new FormClient(stanok);
            if (formClient.ShowDialog() == DialogResult.OK)
            {
                //stanok_ = formClient.Stanok;
                Workshop.DCraftbanch.Add(stanok.CraftbanchirId, stanok);
                UpdateClientsList();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stanok = listView1.SelectedItems[0].Tag as Craftbanch;
            FormClient formClient = new FormClient(stanok);
            if (formClient.ShowDialog() == DialogResult.OK)
            {
                UpdateClientsList();
            }
        }

        private void UpdateClientsList()
        {
            listView1.Items.Clear();
            foreach (var item in Workshop.DCraftbanch)
            {
                var client = item.Value;
                var listViewItem = new ListViewItem
                {
                    Tag = client,
                    Text = client.ToString()
                };
                listView1.Items.Add(listViewItem);
            }
        }


        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var nameRepair = new NameRepair();
            FormRepair formClient = new FormRepair(nameRepair);
            if (formClient.ShowDialog() == DialogResult.OK)
            {
                //nameRepair = formClient.NameRepair;
                Workshop.DNameRepair.Add(nameRepair.NameRepairId, nameRepair);
                UpdateRoomsList();
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var nameRepair = listView1.SelectedItems[0].Tag as NameRepair;
            FormRepair formClient = new FormRepair(nameRepair);
            if (formClient.ShowDialog() == DialogResult.OK)
            {
                UpdateRoomsList();
            }
        }

        private void UpdateRoomsList()
        {
            listView1.Items.Clear();
            foreach (var item in Workshop.DNameRepair)
            {
                var room = item.Value;
                var listViewItem = new ListViewItem
                {
                    Tag = room,
                    Text = room.ToString()
                };
                listView1.Items.Add(listViewItem);
            }
        }


        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void workshopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            

            var repair = new Repair();
            FormWorkshop formClient = new FormWorkshop(repair);
            if (formClient.ShowDialog() == DialogResult.OK)
            {
                repair = formClient.Repair;
                Workshop.DRepair.Add(repair.RepairId, repair);
                UpdateSettlementList();
            }
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var repair = listView1.SelectedItems[0].Tag as Repair;
            FormWorkshop formSettlement = new FormWorkshop(repair);
            if (formSettlement.ShowDialog() == DialogResult.OK)
            {
                UpdateSettlementList();
            }

        }

        private void UpdateSettlementList()
        {
            listView1.Items.Clear();
            foreach (var settlement in Workshop.DRepair)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = settlement,
                    Text = settlement.ToString()
                };
                
                //listViewItem.SubItems.Add(settlement.Value.NameRepair.Price.ToString());
                //listViewItem.SubItems.Add(settlement.Value.DateStart.ToShortDateString());
                //listViewItem.SubItems.Add(settlement.EndDate.ToShortDateString());
                listView1.Items.Add(listViewItem);
            }

        }

        private void craftbanchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateClientsList();
        }

        private void nameRepairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateRoomsList();
        }

        private void workshopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateSettlementList();
        }
    }
}