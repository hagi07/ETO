using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ETO
{
    public partial class InformacionExalumnos : Form
    {
        string ape;
        string nombre;
        string fecBaja;
        string obs1;
        string obs2; 
        string obs3; 
        string obs4; 
        string obs5;
        string fab; 
        string dd;
        string mm; 
        string aa;
        
        public InformacionExalumnos()
        {
            InitializeComponent();
        }

        public InformacionExalumnos(string nombre, string fecBaja, string obs1, string obs2, string obs3, string obs4, string obs5)
        {
            InitializeComponent();
            /*this.ape = ape;
            this.nombre = nombre;
            this.fecBaja = fecBaja;
            this.obs1 = obs1;
            this.obs2 = obs2;
            this.obs3 = obs3;
            this.obs4 = obs4;
            this.obs5 = obs5;
            this.fab = fab;
            this.dd = dd;
            this.mm = mm;
            this.aa = aa;*/

            textBoxNOMBRE.Text = nombre;
            textBoxFECBAJA.Text = fecBaja;
            textBoxOBS1.Text = obs1;
            textBoxOBS2.Text = obs2;
            textBoxOBS3.Text = obs3;
            textBoxOBS4.Text = obs4;
            textBoxOBS5.Text = obs5;

            /*System.IO.DriveInfo di = new System.IO.DriveInfo(@"C:\Fotos ETO\");
            Console.WriteLine(di.TotalFreeSpace);
            Console.WriteLine(di.VolumeLabel);

            System.IO.DirectoryInfo dirInfo = di.RootDirectory;
            Console.WriteLine(dirInfo.Attributes.ToString());

            System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.png");
            */
            string[] files = Directory.GetFiles(@"C:\Fotos ETO\", "*.*");
            bool ok = false;
            int indice = 0;

            for (int i = 0; i < files.Length; i++) 
            {
                string[] valor = files[i].Split('\\');
                if (valor[valor.Length - 1] == (nombre + ".jpg"))
                {
                    ok = true;
                    indice = i;
                }
            }

            if (ok)
            {
                pictureBox.Image = Image.FromFile(files[indice]);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox.Size = new System.Drawing.Size(100, 100);
                pictureBox.Image = Image.FromFile("NotUser.png");
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CANCELAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
