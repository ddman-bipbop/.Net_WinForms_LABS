using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12
{
    public partial class PrintForm : Form
    {
        #region constant fields
        private const string standardTitle = "CapsEditor";
        // default text in titlebar
        private const uint margin = 10;
        // horizontal and vertical margin in client area
        #endregion

        private int printingPageNo = 0;

        #region Member fields
        private ArrayList documentLines = new ArrayList();   // the 'document'
        private uint lineHeight;        // height in pixels of one line
        private Size documentSize;      // how big a client area is needed to 
                                        // display document
        private uint nLines;            // number of lines in document
        private Font mainFont;          // font used to display all lines
        private Font emptyDocumentFont; // font used to display empty message
        private Brush mainBrush = Brushes.Blue;
        // brush used to display document text
        private Brush emptyDocumentBrush = Brushes.Red;
        // brush used to display empty document message
        private Point mouseDoubleClickPosition;
        // location mouse is pointing to when double-clicked
        private OpenFileDialog fileOpenDialog = new OpenFileDialog();
        // standard open file dialog
        private bool documentHasData = false;
        // set to true if document has some data in it
        #endregion

        string firstName;
        string secondName;
        string positions;
        int experience;
        PictureBox photo;
        int coutStr;

        private void CreateFonts()
        {
            mainFont = new Font("Arial", 10);
            lineHeight = (uint)mainFont.Height;
            emptyDocumentFont = new Font("Verdana", 13, FontStyle.Bold);
        }

        public PrintForm(TextBox firstName, TextBox secondName, string positions, DateTimePicker experience, PictureBox photo)
        {
            InitializeComponent();
            CreateFonts();
            this.positions = positions;
            this.firstName = firstName.Text;
            this.secondName = secondName.Text;
            //this.experience = experience.Value;
            this.photo = photo;
            this.LoadFile();
        }


        private void LoadFile()
        {
            documentLines.Clear();
            nLines = 0;
            TextLineInformation nextLineInfo;

            if (firstName.Length > 0)
            {
                nextLineInfo = new TextLineInformation();
                nextLineInfo.Text = $"\r\nКлуб: {firstName}\r\n";
                documentLines.Add(nextLineInfo);
                ++nLines;
                ++coutStr;
            }
            if (secondName.Length > 0)
            {
                nextLineInfo = new TextLineInformation();
                nextLineInfo.Text = $"\r\nОписание: {secondName}\r\n";
                documentLines.Add(nextLineInfo);
                ++nLines;
                ++coutStr;
            }
            if (positions != null)
            {
                nextLineInfo = new TextLineInformation();
                nextLineInfo.Text = $"\r\nВид спорта: {positions}\r\n";
                documentLines.Add(nextLineInfo);
                ++nLines;
                ++coutStr;
            }/*
            if (experience > -1)
            {
                nextLineInfo = new TextLineInformation();
                nextLineInfo.Text = $"\r\nСтаж: {experience}\r\n";
                documentLines.Add(nextLineInfo);
                ++nLines;
                ++coutStr;
            }*/
            if (photo.Image != null)
            {
                nextLineInfo = new TextLineInformation();
                nextLineInfo.Text = "\r\nФото:\r\n";
                documentLines.Add(nextLineInfo);
                ++nLines;
                ++coutStr;
            }

            if (nLines > 0)
            {
                documentHasData = true;
            }
            else
            {
                documentHasData = false;
            }

            CalculateLineWidths();
            CalculateDocumentSize();

            this.Text = standardTitle + " - " + firstName;
            this.Invalidate();
        }

        private void CalculateLineWidths()
        {
            Graphics dc = this.CreateGraphics();
            foreach (TextLineInformation nextLine in documentLines)
            {
                nextLine.Width = (uint)dc.MeasureString(nextLine.Text,
                    mainFont).Width;
            }
        }
        private void CalculateDocumentSize()
        {
            if (!documentHasData)
            {
                documentSize = new Size(100, 200);
            }
            else
            {
                documentSize.Height = (int)(nLines * lineHeight) + 2 * (int)margin;
                uint maxLineLength = 0;
                foreach (TextLineInformation nextWord in documentLines)
                {
                    uint tempLineLength = nextWord.Width + 2 * margin;
                    if (tempLineLength > maxLineLength)
                        maxLineLength = tempLineLength;
                }
                documentSize.Width = (int)maxLineLength;
            }
            this.AutoScrollMinSize = documentSize;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            int scrollPositionX = this.AutoScrollPosition.X;
            int scrollPositionY = this.AutoScrollPosition.Y;
            dc.TranslateTransform(scrollPositionX, scrollPositionY);

            if (!documentHasData)
            {
                dc.DrawString("<Empty document>", emptyDocumentFont,
                    emptyDocumentBrush, new Point(20, 20));
                base.OnPaint(e);
                return;
            }
            // work out which lines are in clipping rectangle
            int minLineInClipRegion =
                WorldYCoordinateToLineIndex(e.ClipRectangle.Top - scrollPositionY);
            if (minLineInClipRegion == -1)
                minLineInClipRegion = 0;
            int maxLineInClipRegion =
                WorldYCoordinateToLineIndex(e.ClipRectangle.Bottom -
                scrollPositionY);
            if (maxLineInClipRegion >= this.documentLines.Count ||


                maxLineInClipRegion == -1)
                maxLineInClipRegion = this.documentLines.Count - 1;

            TextLineInformation nextLine;
            for (int i = minLineInClipRegion; i <= maxLineInClipRegion; i++)
            {
                nextLine = (TextLineInformation)documentLines[i];
                dc.DrawString(nextLine.Text, mainFont, mainBrush,
                    this.LineIndexToWorldCoordinates(i));
            }

            if (photo.Image != null) dc.DrawImage(photo.Image, new Point(0, 25 * coutStr));
            base.OnPaint(e);
        }

        private Point LineIndexToWorldCoordinates(int index)
        {
            Point TopLeftCorner = new Point(
                (int)margin, (int)(lineHeight * index + margin));
            return TopLeftCorner;
        }

        private int WorldYCoordinateToLineIndex(int y)
        {
            if (y < margin)
                return -1;
            return (int)((y - margin) / lineHeight);
        }

        private int WorldCoordinatesToLineIndex(Point position)
        {
            if (!documentHasData)
                return -1;
            if (position.Y < margin || position.X < margin)
                return -1;
            int index = (int)(position.Y - margin) / (int)this.lineHeight;
            // check position isn't below document
            if (index >= documentLines.Count)
                return -1;
            // now check that horizontal position is within this line
            TextLineInformation theLine =
                (TextLineInformation)documentLines[index];
            if (position.X > margin + theLine.Width)
                return -1;

            // all is OK. We can return answer
            return index;
        }

        private Point LineIndexToPageCoordinates(int index)
        {
            return LineIndexToWorldCoordinates(index) +
                new Size(AutoScrollPosition);
        }

        private int PageCoordinatesToLineIndex(Point position)
        {
            return WorldCoordinatesToLineIndex(position - new
                Size(AutoScrollPosition));
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mouseDoubleClickPosition = new Point(e.X, e.Y);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            int i = PageCoordinatesToLineIndex(this.mouseDoubleClickPosition);
            if (i >= 0)
            {
                TextLineInformation lineToBeChanged =
                    (TextLineInformation)documentLines[i];
                lineToBeChanged.Text = lineToBeChanged.Text.ToUpper();
                Graphics dc = this.CreateGraphics();
                uint newWidth = (uint)dc.MeasureString(lineToBeChanged.Text,
                    mainFont).Width;
                if (newWidth > lineToBeChanged.Width)
                    lineToBeChanged.Width = newWidth;
                if (newWidth + 2 * margin > this.documentSize.Width)
                {
                    this.documentSize.Width = (int)newWidth;
                    this.AutoScrollMinSize = this.documentSize;
                }
                Rectangle changedRectangle = new Rectangle(
                    LineIndexToPageCoordinates(i),
                    new Size((int)newWidth,
                    (int)this.lineHeight));
                this.Invalidate(changedRectangle);
            }
            base.OnDoubleClick(e);
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {

        }
        
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            float yPos = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            int linesPerPage = (int)(e.MarginBounds.Height /
                mainFont.GetHeight(e.Graphics));
            //			linesPerPage = 10;
            int lineNo = this.printingPageNo * linesPerPage;

            // Print each line of the file.
            int count = 0;
            while (count < linesPerPage && lineNo < this.nLines)
            {
                line = ((TextLineInformation)this.documentLines[lineNo]).Text;
                yPos = topMargin + (count * mainFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, mainFont, Brushes.Blue,
                    leftMargin, yPos, new StringFormat());
                lineNo++;
                count++;
            }

            if (photo.Image != null) e.Graphics.DrawImage(photo.Image, new Point(100, 50 * coutStr));

            // If more lines exist, print another page.
            if (this.nLines > lineNo)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
            printingPageNo++;
        }
       

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler
                (this.pd_PrintPage);
            pd.Print();
            MessageBox.Show(pd.PrinterSettings.PrinterName);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler
                (this.pd_PrintPage);
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    class TextLineInformation
    {
        public string Text;
        public uint Width;
    }
}
