using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Add_registry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //MessageBox.Show(Application.ExecutablePath.ToString());
            
        }
        string _path = "";
        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey rk1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string a = (string)rk1.GetValue("MS_Update");
            if (a == null)
            {
                rk1.SetValue("MS_Update", "\"" + _path + "\"");
                MessageBox.Show("Added");
            }
            else
            {
                MessageBox.Show("Registry already exist");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;
            string path = "";

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                _path = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
            }
            string filename = Path.GetFileName(_path);

            //MessageBox.Show(path);
        }
    }
}
