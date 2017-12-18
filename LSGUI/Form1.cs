using AdvancedBinary;
using LucaSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        private void cZ1ToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Multiselect = true;

            if (FD.ShowDialog() != DialogResult.OK)
                return;
            foreach (string FN in FD.FileNames) {
                byte[] Img = File.ReadAllBytes(FN);
               
                /*//commented this don't works.
                CZ1Parser Reader = new CZ1Parser(Img);
                var Image = Reader.Decode();

                string Out = FD.FileName + "-Decoded.bin";
                StructWriter Writer = new StructWriter(Out);
                for (uint i = 0; i < Image.Length; i++)
                    Writer.WriteStruct(ref Image[i]);

                Writer.Close();*/

                Bitmap Picture = new CZ0Parser(Img).Import();
                Picture.Save(FN + ".png", ImageFormat.Png);
            }
            MessageBox.Show("Textures Decoded.", "LSGUI");
        }
    }
}
