using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Text;

namespace WindowsFormsApp_FOR_LABS
{
    [Serializable]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("ASCII");
            comboBox1.Items.Add("Unicode");
            comboBox1.Items.Add("UTF8");
            comboBox1.Items.Add("UTF7");
            comboBox1.Items.Add("UTF32");

            Encoding ascii = Encoding.ASCII,
                     unicode = Encoding.Unicode,
                     utf8 = Encoding.UTF8,
                     utf7 = Encoding.UTF7,
                     utf32 = Encoding.UTF32;

            comboBox2.Items.Add(ascii);
            comboBox2.Items.Add(unicode);
            comboBox2.Items.Add(utf8);
            comboBox2.Items.Add(utf7);
            comboBox2.Items.Add(utf32);

            textBox3.Text = "Lab9.txt";
        }



        private void Form1_Load_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем объекты двух кодировок.
            Encoding ascii   = Encoding.ASCII, 
                     unicode = Encoding.Unicode,
                     utf8    = Encoding.UTF8, 
                     utf7    = Encoding.UTF7, 
                     utf32   = Encoding.UTF32;

            byte[] readStringBytes, writeStringBytes = { };
            using (StreamWriter writer = new StreamWriter("Lab9.txt", false))
            {
                string text = textBox1.Text;
                Encoding temp = (System.Text.Encoding)comboBox2.SelectedItem;
                char[] chTemp = { };
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "ASCII":
                        readStringBytes = ascii.GetBytes(text);
                        writeStringBytes = Encoding.Convert(ascii, temp, readStringBytes);
                        chTemp = new char[temp.GetCharCount(writeStringBytes, 0, writeStringBytes.Length)];

                        break;
                    case "Unicode":
                        readStringBytes = unicode.GetBytes(text);
                        writeStringBytes = Encoding.Convert(unicode, temp, readStringBytes);
                        chTemp = new char[temp.GetCharCount(writeStringBytes, 0, writeStringBytes.Length)];
                        break;
                    case "UTF8":
                        readStringBytes = utf8.GetBytes(text);
                        writeStringBytes = Encoding.Convert(utf8, temp, readStringBytes);
                        chTemp = new char[temp.GetCharCount(writeStringBytes, 0, writeStringBytes.Length)];
                        break;
                    case "UTF7":
                        readStringBytes = utf7.GetBytes(text);
                        writeStringBytes = Encoding.Convert(utf7, temp, readStringBytes);
                        chTemp = new char[temp.GetCharCount(writeStringBytes, 0, writeStringBytes.Length)];
                        break;
                    case "UTF32":
                        readStringBytes = utf32.GetBytes(text);
                        writeStringBytes = Encoding.Convert(utf32, temp, readStringBytes);
                        chTemp = new char[temp.GetCharCount(writeStringBytes, 0, writeStringBytes.Length)];
                        break;
                }
                temp.GetChars(writeStringBytes, 0, writeStringBytes.Length, chTemp, 0);
                string finalString = new string(chTemp);


                //writeStringBytes = Encoding.Convert()

                // Перевод строки в массив байт (byte[]).

                //byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

                // Конвертация массива байт в массив символов и строку.
                // Пример использования GetCharCount/GetChars.
                //char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
                //ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
                //string asciiString = new string(asciiChars);


                //writer.WriteLine(asciiString);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && comboBox1.GetItemText(comboBox1.SelectedIndex) != "-1")
            {
                
                string path = textBox3.Text;
                // асинхронное чтение
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.OpenOrCreate), (System.Text.Encoding)comboBox2.SelectedItem))
                {
                    textBox1.Text = await reader.ReadToEndAsync();                 
                }
            }
            else
                return;
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}