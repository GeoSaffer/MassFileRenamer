using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MassFileRenamer
{
    public partial class Form1 : Form
    {
        string oldStr, newStr;
        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();

        public Form1()
        {
            InitializeComponent();
        }

        private void get_filenames()
        {
            DirectoryInfo diDirectory;
            FileInfo[] fiFiles;
            int i;

            diDirectory = new DirectoryInfo(txtFolder.Text + @"\");
            fiFiles = diDirectory.GetFiles();

            if (fiFiles != null)
            {
               // MessageBox.Show(txtFolder.Text + @"\");
                for (i = 0; i < fiFiles.Length; i++)
                {
                   // MessageBox.Show(fiFiles[i].Name.ToString());
                    try
                    {
                        File.Move(txtFolder.Text + @"\" + fiFiles[i].Name.ToString(), txtFolder.Text + @"\" + fiFiles[i].Name.Replace(txtOldStr.Text, txtNewStr.Text).ToString());
                    }
                    catch (Exception ex)
                    {
                        // throw;
                        MessageBox.Show("Multiple files of the same name can not exist !");
                    }
                }
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtFolder.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            get_filenames();
            Cursor.Current = Cursors.Default;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void txtOldStr_MouseHover(object sender, EventArgs e)
        {
            
            
            ToolTip1.IsBalloon = true;
            ToolTip1.SetToolTip(this.txtOldStr, "The text that you would like to replace.");
            ToolTip1.ShowAlways = true;

            ToolTip1.Active = true;
        }

        private void txtNewStr_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.SetToolTip(this.txtNewStr, "The text that you would like to replace the above text.");
            ToolTip1.ShowAlways = true;
            ToolTip1.Active = true;
        }

        private void txtOldStr_MouseEnter(object sender, EventArgs e)
        {
            ToolTip1.Active = false;
        }

        private void txtNewStr_MouseEnter(object sender, EventArgs e)
        {
            ToolTip1.Active = false;
        }
        
    }
}
