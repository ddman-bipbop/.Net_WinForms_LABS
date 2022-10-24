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
        //private Craftbanch stanok_;
        //private NameRepair nameRepair_;
        //private Repair repair_;

        private readonly Workshop _hotel = Workshop.Instance;
        readonly FormRepair _formRoom = new FormRepair();
        readonly FormClient _formClient = new FormClient();
        readonly FormWorkshop _formSettlement = new FormWorkshop();


        public Form1()
        {
            InitializeComponent();
            _hotel.ClientAdded += _hotel_ClientAdded;
            _hotel.RoomAdded += _hotel_RoomAdded;
            _hotel.SettlementAdded += _hotel_SettlementAdded;
            _hotel.ClientRemoved += _hotel_ClientRemoved;
            _hotel.RoomRemoved += _hotel_RoomRemoved;
            _hotel.SettlementRemoved += _hotel_SettlementRemoved;

        }

        private void _hotel_SettlementRemoved(object sender, EventArgs e)
        {
            var settlement = sender as Repair;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if ((Repair)listView1.Items[i].Tag == settlement)
                {
                    listView1.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _hotel_RoomRemoved(object sender, EventArgs e)
        {
            var roomNumber = (int)sender;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (((NameRepair)listView2.Items[i].Tag).NameRepairId == roomNumber)
                {
                    listView2.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _hotel_ClientRemoved(object sender, EventArgs e)
        {
            var clientId = (int)sender;
            for (int i = 0; i < listView3.Items.Count; i++)
            {
                if (((Craftbanch)listView3.Items[i].Tag).CraftbanchId == clientId)
                {
                    listView3.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _hotel_SettlementAdded(object sender, EventArgs e)
        {
            var settlement = sender as Repair;
            if (settlement != null)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = settlement,
                    Text = settlement.ToString()
                };
                //listViewItem.SubItems.Add(settlement.Room.ToString());
                //listViewItem.SubItems.Add(settlement.StartDate.ToShortDateString());
                //listViewItem.SubItems.Add(settlement.EndDate.ToShortDateString());
                listView1.Items.Add(listViewItem);
            }
        }

        private void _hotel_RoomAdded(object sender, EventArgs e)
        {
            var room = sender as NameRepair;
            if (room != null)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = room,
                    Text = room.ToString()
                };
                listView2.Items.Add(listViewItem);
            }
        }

        private void _hotel_ClientAdded(object sender, EventArgs e)
        {
            var client = sender as Craftbanch;
            if (client != null)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = client,
                    Text = client.ToString()
                };
                listView3.Items.Add(listViewItem);
            }
        }



       

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var client = new Craftbanch();
            _formClient.Client = client;
            if (_formClient.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _hotel.AddClient(client);
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
                var client = listView3.SelectedItems[0].Tag as Craftbanch;
                _formClient.Client = client;
                if (_formClient.ShowDialog() == DialogResult.OK)
                {
                    listView3.SelectedItems[0].Text = _formClient.Client.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с станком");
            }

        }

        //private void UpdateClientsList()
        //{
        //    listView1.Items.Clear();
        //    foreach (var item in Workshop.DCraftbanch)
        //    {
        //        var client = item.Value;
        //        var listViewItem = new ListViewItem
        //        {
        //            Tag = client,
        //            Text = client.ToString()
        //        };
        //        listView1.Items.Add(listViewItem);
        //    }
        //}


        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var room = new NameRepair();
            _formRoom.Room = room;
            if (_formRoom.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _hotel.AddRoom(room);
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
                var room = listView2.SelectedItems[0].Tag as NameRepair;
                _formRoom.Room = room;
                if (_formRoom.ShowDialog() == DialogResult.OK)
                {
                    listView2.SelectedItems[0].Text = _formRoom.Room.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с номером");
            }

        }

        //private void UpdateRoomsList()
        //{
        //    listView1.Items.Clear();
        //    foreach (var item in Workshop.DNameRepair)
        //    {
        //        var room = item.Value;
        //        var listViewItem = new ListViewItem
        //        {
        //            Tag = room,
        //            Text = room.ToString()
        //        };
        //        listView1.Items.Add(listViewItem);
        //    }
        //}


        

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var settlement = new Repair();
            _formSettlement.Settlement = settlement;
            if (_formSettlement.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _hotel.AddSettlement(settlement);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                var settlement = listView1.SelectedItems[0].Tag as Repair;
                _formSettlement.Settlement = settlement;
                if (_formSettlement.ShowDialog() == DialogResult.OK)
                {
                    settlement = _formSettlement.Settlement;
                    var listViewItem = listView1.SelectedItems[0];
                    listViewItem.Text = settlement.ToString();
                    //listViewItem.SubItems[1].Text = settlement.Room.ToString();
                    //listViewItem.SubItems[2].Text = settlement.StartDate.ToShortDateString();
                    //listViewItem.SubItems[3].Text = settlement.EndDate.ToShortDateString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с поселением");
            }


        }

        //private void UpdateSettlementList()
        //{
        //    listView1.Items.Clear();
        //    foreach (var settlement in Workshop.DRepair)
        //    {
        //        var listViewItem = new ListViewItem
        //        {
        //            Tag = settlement,
        //            Text = settlement.ToString()
        //        };
                
        //        //listViewItem.SubItems.Add(settlement.Value.NameRepair.Price.ToString());
        //        //listViewItem.SubItems.Add(settlement.Value.DateStart.ToShortDateString());
        //        //listViewItem.SubItems.Add(settlement.EndDate.ToShortDateString());
        //        listView1.Items.Add(listViewItem);
        //    }

        //}

        private void craftbanchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //UpdateClientsList();
        }

        private void nameRepairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //UpdateRoomsList();
        }

        private void workshopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //UpdateSettlementList();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void listView3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var client = listView3.SelectedItems[0].Tag as Craftbanch;
                    if (client != null)
                    {
                        _hotel.RemoveClient(client.CraftbanchId);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с клиентом");
                }
            }

        }

        private void listView2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var room = listView2.SelectedItems[0].Tag as NameRepair;
                    if (room != null)
                    {
                        _hotel.RemoveRoom(room.NameRepairId);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с номером");
                }
            }

        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var settlement = listView1.SelectedItems[0].Tag as Repair;
                    if (settlement != null)
                    {
                        _hotel.RemoveSettlement(settlement);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с поселением");
                }
            }

        }
    }
}