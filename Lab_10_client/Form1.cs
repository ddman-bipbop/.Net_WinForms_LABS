using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Concurrent;
using ClassLibraryAuto;

namespace Lab_10_client
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

        // Добавить
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[10240];
            try
            {
                AutoRequest request = null;

                int key = ((int)numericUpDown1.Value);

                request = new AutoRequest
                {
                    Auto = new Auto
                    {
                        Brand = textBox1.Text,
                        Color = textBox2.Text,
                        DateCreate = dateTimePicker1.Value
                    },
                    Key = key,
                    Type = AutoRequestType.Add
                };
                string jsonRequest = JsonConvert.SerializeObject(request);
                byte[] msg = Encoding.UTF8.GetBytes(jsonRequest);
                // Отправляем данные через сокет
                sender2.Send(msg);

                // Получаем ответ от сервера
                int bytesRec = sender2.Receive(bytes);
                string jsonRecieve = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                var auto = JsonConvert.DeserializeObject<AutoResponse>(jsonRecieve);

                textBox3.Text = auto.IsSuccess
                    ? "Машина успешно добавлена!"
                    : auto.ErrorMessage;
                

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Загрузить
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            // Буфер для входящих данных
            byte[] bytes = new byte[10240];
            try
            {
                int key = ((int)numericUpDown1.Value);
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

                var auto = JsonConvert.DeserializeObject<AutoResponse>(jsonRecieve);

                if (auto.IsSuccess)
                {
                    textBox3.Text = "Машина найдена!";
                    textBox1.Text = auto.Auto.Brand;
                    textBox2.Text = auto.Auto.Color;
                    dateTimePicker1.Value = auto.Auto.DateCreate;
                }
                else
                {
                    textBox3.Text = auto.ErrorMessage;
                    textBox1.Text = "Error";
                    textBox2.Text = "Error";
                    dateTimePicker1.Value = DateTime.Now;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // Обновить
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[10240];
            try
            {
                AutoRequest request = null;

                int key = ((int)numericUpDown1.Value);

                request = new AutoRequest
                {
                    Auto = new Auto
                    {
                        Brand = textBox1.Text,
                        Color = textBox2.Text,
                        DateCreate = dateTimePicker1.Value
                    },
                    Key = key,
                    Type = AutoRequestType.Update
                };
                string jsonRequest = JsonConvert.SerializeObject(request);
                byte[] msg = Encoding.UTF8.GetBytes(jsonRequest);
                // Отправляем данные через сокет
                sender2.Send(msg);

                // Получаем ответ от сервера
                int bytesRec = sender2.Receive(bytes);
                string jsonRecieve = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                var auto = JsonConvert.DeserializeObject<AutoResponse>(jsonRecieve);

                textBox3.Text = auto.IsSuccess
                    ? "Машина успешно Обновлена!"
                    : auto.ErrorMessage;


            }
            catch (Exception)
            {
                throw;
            }
        }

        // Удалить
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[10240];
            try
            {
                int key = ((int)numericUpDown1.Value);
                AutoRequest request = new AutoRequest
                {
                    Key = key,
                    Type = AutoRequestType.Remove
                };

                string jsonRequest = JsonConvert.SerializeObject(request);
                byte[] msg = Encoding.UTF8.GetBytes(jsonRequest);
                // Отправляем данные через сокет
                sender2.Send(msg);
                // Получаем ответ от сервера
                int bytesRec = sender2.Receive(bytes);
                string jsonRecieve = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                var auto = JsonConvert.DeserializeObject<AutoResponse>(jsonRecieve);

                if (auto.IsSuccess)
                {
                    textBox3.Text = "Машина Удалена!";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    dateTimePicker1.Value = DateTime.Now;
                }
                else
                {
                    textBox3.Text = auto.ErrorMessage;
                    textBox1.Text = "Error";
                    textBox2.Text = "Error";
                    dateTimePicker1.Value = DateTime.Now;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}