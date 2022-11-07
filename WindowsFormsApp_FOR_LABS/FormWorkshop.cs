using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_FOR_LABS;

namespace WindowsFormsApp_FOR_LABS
{
    public partial class FormWorkshop : Form
    {
        private Repair _settlement;
        public Repair Settlement
        {
            get { return _settlement; }
            set
            {
                _settlement = value;
                comboBox1.SelectedItem = _settlement.NameStanok;
                comboBox2.SelectedItem = _settlement.NameRepair;
                dateTimePicker1.Value = _settlement.DateStart;
            }
        }
        private readonly Workshop _hotel = Workshop.Instance;

   

        public FormWorkshop()
        {
            InitializeComponent();
            _hotel.CraftbanchAdded += _hotel_ClientAdded;
            _hotel.CraftbanchRemoved += _hotel_ClientRemoved;
            _hotel.NameRepairAdded += _hotel_RoomAdded;
            _hotel.NameRepairRemoved += _hotel_RoomRemoved;
            foreach (var client in _hotel.Craftbanchs)
            {
                comboBox1.Items.Add(client);
            }
            foreach (var room in _hotel.NameRepairs)
            {
                comboBox2.Items.Add(room);
            }   

        }
        private void _hotel_ClientRemoved(object sender, EventArgs e)
        {
            int key = (int)sender;
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                var client = comboBox1.Items[i] as Craftbanch;
                if (client?.CraftbanchId == key)
                {
                    comboBox1.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _hotel_ClientAdded(object sender, EventArgs e)
        {
            comboBox1.Items.Add(sender);
        }

        private void _hotel_RoomRemoved(object sender, EventArgs e)
        {
            int key = (int)sender;
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                var room = comboBox2.Items[i] as NameRepair;
                if (room?.NameRepairId == key)
                {
                    comboBox2.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _hotel_RoomAdded(object sender, EventArgs e)
        {
            comboBox2.Items.Add(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _settlement.NameStanok = comboBox1.SelectedItem as Craftbanch;
            _settlement.NameRepair = comboBox2.SelectedItem as NameRepair;
            _settlement.DateStart = dateTimePicker1.Value;
        }

        private void FormWorkshop_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

       
    }
}