using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ETO
{
    public partial class Alumnos : Form
    {
        public Alumnos()
        {
            InitializeComponent();  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "NOM like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = bs;
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            string constructor = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + "ALUMNOS.xlsx" + "; Extended Properties =\"Excel 12.0 Xml;HDR=YES;\";";
            OleDbConnection con = new OleDbConnection(constructor);
            OleDbDataAdapter sda = new OleDbDataAdapter("select * from [ALUM$]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
        }

    }
}
