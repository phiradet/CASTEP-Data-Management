using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using OfficeOpenXml;

namespace CASTEP_Management
{

    public partial class Form1 : Form
    {
        CASTEPextract extractor;
        public Form1()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
            InitializeSAveFileDialog();
            extractor = new CASTEPextract(this.progressBar);
        }

        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.
            this.openFileDialog1.Filter =
                "CASTEP (*.castep)|*.castep|" +
                "All files (*.*)|*.*";

            //  Allow the user to select multiple images.
            this.openFileDialog1.Multiselect = true;
            //                   ^  ^  ^  ^  ^  ^  ^

            this.openFileDialog1.Title = "Select CASTEP file";
        }

        private void InitializeSAveFileDialog()
        {
            this.saveFileDialog1.Filter = "Excel (*.xls)|*.xlsx";
            this.saveFileDialog1.FileName = "output.xlsx";
        }

        private string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        private string GetStressFromFilename(string filename)
        {
            Regex stressReg = new Regex(@".*?_(\d+)GPa.castep");
            Match m = stressReg.Match(filename);
            if(m.Success)
                return m.Groups[1].Value;
            else
                return "-1";
        }

        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String path in openFileDialog1.FileNames)
                {
                    ListViewItem lvi = new ListViewItem();
                    String filename = GetFileName(path);
                    lvi.SubItems[0].Text = filename;
                    String stress = GetStressFromFilename(filename);
                    lvi.SubItems.Add(stress);
                    lvi.SubItems.Add(path);
                    list_Files.Items.Add(lvi);
                    //this.filenames.Add(filename);
                    //this.path.Add(path);
                    //this.stress.Add(int.Parse(stress));
                    extractor.AddFilename(path, double.Parse(stress), filename);
                }
                list_Files.AutoResizeColumn(0,
                ColumnHeaderAutoResizeStyle.HeaderSize);
                list_Files.AutoResizeColumn(1,
                    ColumnHeaderAutoResizeStyle.ColumnContent);
                list_Files.AutoResizeColumn(2,
                    ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void btn_SaveFilename_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txt_SaveFilename.Text = saveFileDialog1.FileName;
            }
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            CASTEPinfo info = extractor.Extract();
            info.record.Sort(delegate(CASTEPsubObj c1, CASTEPsubObj c2) { return c1.stress.CompareTo(c2.stress); });
            CASTEPxlsWriter.WriteXLS(info, txt_SaveFilename.Text);
            MessageBox.Show("Successfully write CASTEP data to " + txt_SaveFilename.Text);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            extractor = new CASTEPextract(this.progressBar);
            this.progressBar.Value = 0;
            txt_SaveFilename.Text = "";
            list_Files.Items.Clear();
        }
    }

   }
