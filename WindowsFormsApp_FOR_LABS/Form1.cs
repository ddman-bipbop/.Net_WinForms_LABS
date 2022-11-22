using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowsFormsApp_FOR_LABS
{
    [Serializable]
    public partial class Form1 : Form
    {
        readonly FormError _formError = new FormError();
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
            textBox4.Text = "Lab9.txt";
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

            string text = textBox1.Text;
            Encoding temp = (System.Text.Encoding)comboBox2.SelectedItem;
            char[] chTemp = { };
            switch (comboBox1.SelectedItem.ToString())
            {
                case "ASCII":
                    readStringBytes = ascii.GetBytes(text);
                    writeStringBytes = Encoding.Convert(ascii, temp, readStringBytes);             

                    break;
                case "Unicode":
                    readStringBytes = unicode.GetBytes(text);
                    writeStringBytes = Encoding.Convert(unicode, temp, readStringBytes);
                    
                    break;
                case "UTF8":
                    readStringBytes = utf8.GetBytes(text);
                    writeStringBytes = Encoding.Convert(utf8, temp, readStringBytes);
                    
                    break;
                case "UTF7":
                    readStringBytes = utf7.GetBytes(text);
                    writeStringBytes = Encoding.Convert(utf7, temp, readStringBytes);
                    
                    break;
                case "UTF32":
                    readStringBytes = utf32.GetBytes(text);
                    writeStringBytes = Encoding.Convert(utf32, temp, readStringBytes);
                    
                    break;
            }
            chTemp = new char[temp.GetCharCount(writeStringBytes, 0, writeStringBytes.Length)];
            temp.GetChars(writeStringBytes, 0, writeStringBytes.Length, chTemp, 0);
            string finalString = new string(chTemp);

            string path = textBox4.Text;
            textBox2.Text = finalString;
            using (StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate), temp))
            {             
                writer.WriteLine(finalString);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            
            
            if (textBox3.Text != "" && comboBox1.GetItemText(comboBox1.SelectedIndex) != "-1")
            {
                Encoding temp = Encoding.ASCII;
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "ASCII":
                        temp = Encoding.ASCII;
                        break;
                    case "Unicode":
                        temp = Encoding.Unicode;
                        break;
                    case "UTF8":
                        temp = Encoding.UTF8;
                        break;
                    case "UTF7":
                        temp = Encoding.UTF7;
                        break;
                    case "UTF32":
                        temp = Encoding.UTF32;
                        break;
                }

                string path = textBox3.Text;
                // асинхронное чтение
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.OpenOrCreate), temp))
                {
                    textBox1.Text = await reader.ReadToEndAsync();
                }
            }
            else
            {
                if (_formError.ShowDialog() == DialogResult.OK) 
                {
                    return;
                }
            }
            
            
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string myText = textBox5.Text;

            const string myReg = "using";
            MatchCollection myMatch = Regex.Matches(myText, myReg);

            //Console.WriteLine("Все вхождения строки \"{0}\" в исходной строке: ", myReg);
            foreach (Match i in myMatch) 
            {
                textBox6.Text += i.Index + "\t";
            }
                

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}