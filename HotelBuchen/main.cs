using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBuchen
{
    public partial class main : Form
    {
        private Form1 _form = null;

        private kunden kunde = null;
        public main(Form1 form, kunden kunde)
        {
            InitializeComponent();
            _form = form;
            this.kunde = kunde;

            getAllHotels();
        }

        private void getAllHotels()
        {
            dataGridView1.Columns.Clear();


            string[,] columns = _form.db.getColumnNames("Wohnungen");

            for (int i = 1; i < columns.GetLength(1); i++)
            {
                if (!columns[1,i].Contains("string"))
                {
                    if (columns[1,i].ToLower().Contains("boolean"))
                    {
                        dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn { Name = i.ToString(), HeaderText = columns[0,i] });
                        continue;
                    }

                }
                 dataGridView1.Columns.Add(i.ToString(), columns[0, i]);
            }

            string[,] temp = _form.db.getItem("Select * from Wohnungen;", "Wohnungen");

            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = temp[i, j];
                }
            }
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form.db.CloseDatabase();
            Environment.Exit(1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
