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

        }



        private void Form1_Load_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем объекты двух кодировок.
            Encoding ascii = Encoding.ASCII, unicode = Encoding.Unicode;

            using (StreamWriter writer = new StreamWriter("Lab9.txt", false))
            {
                string text = textBox1.Text;
                string textFile = "";
                foreach (string s in text.Split('\r'))
                {
                    textFile += s;
                }
                // Перевод строки в массив байт (byte[]).
                byte[] unicodeBytes = unicode.GetBytes(textFile);

                byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

                // Конвертация массива байт в массив символов и строку.
                // Пример использования GetCharCount/GetChars.
                char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
                ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
                string asciiString = new string(asciiChars);


                writer.WriteLine(asciiString);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}