using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace WindowsFormsApp_FOR_LABS
{
    [Serializable]
    public partial class Form1 : Form
    {

        private readonly Workshop _workshop = Workshop.Instance;
        readonly FormRepair _formRepair = new FormRepair();
        readonly FormClient _formCraftbanch = new FormClient();
        readonly FormWorkshop _formWorkshop = new FormWorkshop();


        public Form1()
        {
            InitializeComponent();
            _workshop.CraftbanchAdded      += _workshop_CraftbanchAdded;
            _workshop.NameRepairAdded      += _workshop_NameRepairAdded;
            _workshop.RepairAdded          += _workshop_RepairAdded;
            _workshop.CraftbanchRemoved    += _workshop_CraftbanchRemoved;
            _workshop.NameRepairRemoved    += _workshop_NameRepairRemoved;
            _workshop.RepairRemoved        += _workshop_RepairRemoved;

        }

        private void _workshop_RepairRemoved(object sender, EventArgs e)
        {
            var settlement = sender as Repair;
            for (int i = 0; i < tabPage1.Controls.Count; i++)
            {
                if ((tabPage1.Controls[i] as UserControl1)?.Settlement == settlement)
                {
                    tabPage1.Controls.RemoveAt(i);
                    break;
                }
            }

        }

        private void _workshop_NameRepairRemoved(object sender, EventArgs e)
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

        private void _workshop_CraftbanchRemoved(object sender, EventArgs e)
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

        private void _workshop_RepairAdded(object sender, EventArgs e)
        {
            var settlement = sender as Repair;
            if (settlement != null)
            {
                UserControl1 userControl = new UserControl1(settlement)
                {
                    Dock = DockStyle.Top
                }; tabPage1.Controls.Add(userControl);
            }

        }

        private void _workshop_NameRepairAdded(object sender, EventArgs e)
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

        private void _workshop_CraftbanchAdded(object sender, EventArgs e)
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
            _formCraftbanch.Client = client;
            if (_formCraftbanch.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _workshop.AddClient(client);
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
                _formCraftbanch.Client = client;
                if (_formCraftbanch.ShowDialog() == DialogResult.OK)
                {
                    listView3.SelectedItems[0].Text = _formCraftbanch.Client.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с станком");
            }

        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var room = new NameRepair();
            _formRepair.Room = room;
            if (_formRepair.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _workshop.AddRoom(room);
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
                _formRepair.Room = room;
                if (_formRepair.ShowDialog() == DialogResult.OK)
                {
                    listView2.SelectedItems[0].Text = _formRepair.Room.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с видом работы");
            }

        }      

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var settlement = new Repair();
            _formWorkshop.Settlement = settlement;
            if (_formWorkshop.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _workshop.AddSettlement(settlement);
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
                for (int i = 0; i < tabPage1.Controls.Count; i++)
                {
                    var userControl = tabPage1.Controls[i] as UserControl1;
                    if (userControl != null)
                    {
                        if (userControl.Selected)
                        {
                            var settlement = userControl.Settlement;
                            _formWorkshop.Settlement = settlement;
                            if (_formRepair.ShowDialog() == DialogResult.OK)
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
                MessageBox.Show("Не выбрана запись о поселении");
            }



        }

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
                        _workshop.RemoveClient(client.CraftbanchId);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с станком");
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
                        _workshop.RemoveRoom(room.NameRepairId);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с видом работы");
                }
            }

        }


        private void stanokToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Repair));
            
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("Repairs.xml", FileMode.OpenOrCreate))
            {
                
                for (int i = 0; i < tabPage1.Controls.Count; i++)
                {
                    var userControl = tabPage1.Controls[i] as UserControl1;
                    if (userControl != null)
                    {
                        
                        var settlement = userControl.Settlement;

                        formatter.Serialize(fs, settlement);                      
                        
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Repair));
            // десериализация
            using (FileStream fs = new FileStream("Repairs.xml", FileMode.OpenOrCreate))
            {
                // не работает если массив элементов, ТОЛЬКО С ОДНИМ!!!!
                Repair newPerson = (Repair)formatter.Deserialize(fs);
                _workshop.AddSettlement(newPerson);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (StreamWriter jsonStreamWriter = File.CreateText("JSON_Repairs.json"))
            {
                
                
                for (int i = 0; i < tabPage1.Controls.Count; i++)
                {
                    var userControl = tabPage1.Controls[i] as UserControl1;
                    if (userControl != null)
                    {

                        var settlement = userControl.Settlement;
                        JsonSerializer jsonSerializer = new JsonSerializer { Formatting = Formatting.Indented };
                        jsonSerializer.Serialize(jsonStreamWriter, settlement);

                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamReader jsonStreamReader = File.OpenText("JSON_Repairs.json");
            JsonSerializer jsonSerializer = new JsonSerializer();
            Repair newPerson = (Repair)jsonSerializer.Deserialize(jsonStreamReader, typeof(Repair));
            _workshop.AddSettlement(newPerson);
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream binaryFileStream = new FileStream("BIN_Repairs.bin", FileMode.OpenOrCreate))
            {

                formatter.Serialize(binaryFileStream, tabPage1.Controls[0]);


            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream binaryFileStream = new FileStream("BIN_Repairs.bin", FileMode.Open);

            Repair newPerson = (Repair)formatter.Deserialize(binaryFileStream);
            _workshop.AddSettlement(newPerson);

        }
    }
}