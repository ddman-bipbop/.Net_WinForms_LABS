namespace Lab_8
{
    public partial class Form1 : Form
    {
        string path = "";
        FileSystemWatcher watcher;


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            textBoxFileInfo.Text = "";
            try
            {
                if (textBoxInputName.Text != "")
                {
                    path = textBoxInputName.Text;
                    if (!File.Exists(path))
                    {
                        MessageBox.Show("Файла не существует", "ERROR");
                    }
                }
                else
                {
                    openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Filter = "Текстовые файлы|*.txt";
                    if (openFileDialog1.ShowDialog() != DialogResult.OK)
                        return;

                    path = openFileDialog1.FileName;
                    textBoxInputName.Text = path;
                }

                using (StreamReader reader = new StreamReader(path))
                {
                    string text = reader.ReadToEnd();

                    foreach (string s in text.Split('\n'))
                    {
                        textBoxFileInfo.Text += s + "\r\n";
                    }

                    string dir = path.Substring(0, path.LastIndexOf('\\'));

                    watcher = new FileSystemWatcher(dir);
                    watcher.Changed += Watcher_Changed;

                    watcher.IncludeSubdirectories = true;
                    watcher.EnableRaisingEvents = true;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                textBoxFileInfo.Text = "";
                using (StreamReader reader = new StreamReader(path))
                {
                    string text = reader.ReadToEnd();

                    foreach (string s in text.Split('\n'))
                    {
                        textBoxFileInfo.Text += s + "\r\n";
                    }
                }

            }
            catch
            { }
        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    string text = textBoxFileInfo.Text;
                    string textFile = "";
                    foreach (string s in text.Split('\r'))
                    {
                        textFile += s;
                    }

                    writer.WriteLine(textFile);
                }
            }
            catch (Exception ex)
            { }
        }
    }
}