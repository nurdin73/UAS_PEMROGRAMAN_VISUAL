using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS_PV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadFile(string path)
        {
            if (File.Exists(path)) // Percabangan
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines) // Perulangan
                {
                    DisplayLine(line);
                }
            }
            else
            {
                MessageBox.Show("File tidak ditemukan.");
            }
        }

        private void DisplayLine(string line)
        {
            listBox1.Items.Add(line);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                openFileDialog.Title = "Pilih File Teks";

                if (openFileDialog.ShowDialog() == DialogResult.OK) 
                {
                    string filePath = openFileDialog.FileName;

                    // Validasi ekstensi file
                    if (Path.GetExtension(filePath).ToLower() == ".txt")
                    {
                        ReadFile(filePath); 
                    }
                    else
                    {
                        MessageBox.Show("File yang dipilih bukan file teks (.txt).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
