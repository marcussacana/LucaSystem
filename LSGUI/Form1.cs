using LucaSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LSGUI {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e) {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {
            string OutDir = openFileDialog1.FileName + "~\\";
            Stream Packget = new StreamReader(openFileDialog1.FileName).BaseStream;
            var Files = PAKManager.Unpack(Packget);

            if (!Directory.Exists(OutDir))
                Directory.CreateDirectory(OutDir);
            
            foreach (var File in Files) {
                string FN = OutDir + File.FileName;
                int ID = 2;
                while (System.IO.File.Exists(FN))
                    FN = OutDir + File.FileName + "." + ID++;

                Stream Output = new StreamWriter(FN).BaseStream;
                File.Content.CopyTo(Output);
                Output.Close();
            }
            Packget.Close();
            MessageBox.Show("Packget Extracted", "LSGUI");
        }
    }
}
