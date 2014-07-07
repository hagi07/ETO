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
            string constructor = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + "ALUMNOS.xlsx" + "; Extended Properties =\"Excel 12.0 Xml;HDR=YES;\";";
            OleDbConnection con = new OleDbConnection(constructor);
            OleDbDataAdapter sda = new OleDbDataAdapter("select * from [ALUM$]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }


    }
}
