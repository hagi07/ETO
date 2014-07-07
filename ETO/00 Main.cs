using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETO
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Fondo panel = new Fondo();
            panel.Show();
        }

        private void Inscripciones_Click(object sender, EventArgs e)
        {
            Asistencias panel = new Asistencias();
            panel.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumnos panel = new Alumnos();
            panel.Show();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
