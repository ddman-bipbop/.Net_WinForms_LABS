namespace Lab_8
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxInputName = new System.Windows.Forms.TextBox();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.buttonSaveFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBoxFileInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxInputName
            // 
            this.textBoxInputName.Location = new System.Drawing.Point(38, 25);
            this.textBoxInputName.Name = "textBoxInputName";
            this.textBoxInputName.Size = new System.Drawing.Size(617, 27);
            this.textBoxInputName.TabIndex = 0;
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new System.Drawing.Point(661, 25);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(94, 29);
            this.buttonLoadFile.TabIndex = 2;
            this.buttonLoadFile.Text = "Открыть";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // buttonSaveFile
            // 
            this.buttonSaveFile.Location = new System.Drawing.Point(341, 398);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(94, 29);
            this.buttonSaveFile.TabIndex = 3;
            this.buttonSaveFile.Text = "Сохранить";
            this.buttonSaveFile.UseVisualStyleBackColor = true;
            this.buttonSaveFile.Click += new System.EventHandler(this.buttonSaveFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxFileInfo
            // 
            this.textBoxFileInfo.Location = new System.Drawing.Point(38, 60);
            this.textBoxFileInfo.Multiline = true;
            this.textBoxFileInfo.Name = "textBoxFileInfo";
            this.textBoxFileInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFileInfo.Size = new System.Drawing.Size(717, 332);
            this.textBoxFileInfo.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxFileInfo);
            this.Controls.Add(this.buttonSaveFile);
            this.Controls.Add(this.buttonLoadFile);
            this.Controls.Add(this.textBoxInputName);
            this.Name = "Form1";
            this.Text = "Текстовый редактор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxInputName;
        private Button buttonLoadFile;
        private Button buttonSaveFile;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private TextBox textBoxFileInfo;
    }
}