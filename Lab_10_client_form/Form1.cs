using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ClassLibraryAuto2;
using Newtonsoft.Json;


namespace Lab_10_client_form
{
    public partial class Form1 : Form
    {
        static public IPHostEntry ipHost = Dns.GetHostEntry("localhost");
        static public IPAddress ipAddr = ipHost.AddressList[0];
        static public IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

        Socket sender2 = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        public Form1()
        {
            InitializeComponent();

            // Соединяем сокет с удаленной точкой
            sender2.Connect(ipEndPoint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // Добавить
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[10240];

           
            try
            {
                AutoRequest request = null;

                string title = textBox1.Text.Length == 0 ? "Debug" : textBox1.Text;

                request = new AutoRequest
                {
                    Auto = new Auto { Name = title },
                    Key = title,
                    Type = AutoRequestType.Add
                };
                string jsonRequest = JsonConvert.SerializeObject(request);
                byte[] msg = Encoding.UTF8.GetBytes(jsonRequest);
                // Отправляем данные через сокет
                sender2.Send(msg);

                // Получаем ответ от сервера
                int bytesRec = sender2.Receive(bytes);
            }
            catch (Exception)
            {
                throw;
            }
            
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
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
            */
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[10240];

            string key = textBox1.Text.Length == 0 ? "Debug" : textBox1.Text;
            AutoRequest request = new AutoRequest
            {
                Key = key,
                Type = AutoRequestType.Get
            };

            string jsonRequest = JsonConvert.SerializeObject(request);
            byte[] msg = Encoding.UTF8.GetBytes(jsonRequest);
            // Отправляем данные через сокет
            sender2.Send(msg);
            // Получаем ответ от сервера
            int bytesRec = sender2.Receive(bytes);
            string jsonRecieve = Encoding.UTF8.GetString(bytes, 0, bytesRec);

            //Auto temp = JsonConvert.DeserializeObject(jsonRecieve);
            
            //textBox2.Text = autoRecieve.Name;
        }
    }
}
