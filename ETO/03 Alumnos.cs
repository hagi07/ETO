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
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + "Exalumnos.xlsx" + "; Extended Properties =\"Excel 12.0 Xml;HDR=YES;\";");
        
        public Alumnos()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "NOMBRE like '%" + textBox1.Text + "%'";
                dataGridView1.DataSource = bs;
            }
            catch (Exception exception) 
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            
            OleDbDataAdapter sda = new OleDbDataAdapter("select * from [Hoja1$]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.VirtualMode = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            


            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
                return;

            /*System.Windows.Forms.Form form = new Form();

            int count = 0;
            int width = 0;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Top = 10;
            pictureBox.Left = 10;
            pictureBox.Size = new System.Drawing.Size(100, 100);
            pictureBox.Image = Image.FromFile("NotUser.png");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            form.Controls.Add(pictureBox);

            foreach (DataGridViewCell cell in this.dataGridView1.SelectedRows[0].Cells)
            {
                string value = cell.Value == null ? string.Empty : cell.Value.ToString();
                
                Label label = new Label();
                label.Text = dataGridView1.Columns[count].Name;
                label.Left = 10;
                label.Top = 27 * (count + 1) + 110;
                label.AutoSize = true;

                TextBox textBox = new TextBox();
                textBox.Text = value;
                textBox.Left = dataGridView1.Columns[count].Name.Length * 10 + 25;
                textBox.Top = 27 * (count + 1) + 110;
                
                Size size = TextRenderer.MeasureText(value, textBox.Font);
                textBox.Width = size.Width + 15;

                if (value.Length == 0)
                    textBox.Width = 100;

                if(textBox.Width > width)
                    width = textBox.Width;                

                form.Controls.Add(label);
                form.Controls.Add(textBox);

                count++;
            }

            Button button = new Button();
            button.Text = "Aceptar";
            button.Top = 27 * (count + 1) + 150;
            button.AutoSize = true;
            button.Left = 20;
            form.Controls.Add(button);

            button.Click += new System.EventHandler(ButtonClick); 

            form.Height = (count + 1) * 45;
            form.Width = width + 130;
            
            form.Show();*/

            string[] datos = new string[dataGridView1.SelectedRows[0].Cells.Count];
            
            /*int count = 0;
            foreach (DataGridViewCell cell in this.dataGridView1.SelectedRows[0].Cells)
            {
                string value = cell.Value == null ? string.Empty : cell.Value.ToString();
                datos[count] = value;
                count++;
            }*/

            for (int i = 0; i < dataGridView1.SelectedRows[0].Cells.Count; i++) 
            {
                datos[i] = dataGridView1.SelectedRows[0].Cells[i].Value.ToString();
            }
            InformacionExalumnos panel = new InformacionExalumnos(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6]);
            panel.Show();
        }

        private void ButtonClick(object sender, System.EventArgs e)
        {
            MessageBox.Show("Funciona");
        }

        private void Alumnos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        private void Alumnos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(con.State == ConnectionState.Open)
                con.Close();
        }
    }
}
