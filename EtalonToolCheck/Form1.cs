using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace EtalonToolCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fswEtaalon_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            var etalonFolder = ConfigurationManager.AppSettings.Get("EtalonFolder\\");
            var zbFolder = ConfigurationManager.AppSettings.Get("ZBFolder");
            try
            {
                MessageBox.Show("Файли які змінювались " + e.Name);
                File.Copy(etalonFolder, zbFolder + "\\" + e.Name + ".btw", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex.Message);
            }
            
            textBox1.Text += "Изменен файл " + e.FullPath + "\r\n";
        }

        private void fswEtaalon_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            textBox1.Text += "Создан файл " + e.FullPath + "\r\n";
        }

        private void fswEtaalon_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            textBox1.Text += "Удален файл " + e.FullPath + "\r\n";
        }

        private void fswEtaalon_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            textBox1.Text += "Переименован файл " + e.FullPath + "\r\n";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var etalonFolder = ConfigurationManager.AppSettings.Get("EtalonFolder");
            var zbFolder = ConfigurationManager.AppSettings.Get("ZBFolder");
            lblFolder.Text = "Отслежуемая папка: " + etalonFolder;
            fswEtaalon.Path = etalonFolder;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            var etalonFolder = ConfigurationManager.AppSettings.Get("EtalonFolder");
            Process.Start("explorer.exe", etalonFolder);
        }
    }
}
