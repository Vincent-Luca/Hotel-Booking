using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBuchen
{
    public partial class Form1 : Form
    {
        public Databank db;

        public Form1()
        {
            InitializeComponent();
            db = new Databank("Ferienwohnungen.mdb");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text)&& !String.IsNullOrEmpty(textBox2.Text))
            {
                string[,] kunde = db.getItem("Select * from Kundendaten where Benutzername = '"+ textBox1.Text + "' and Passwort = '"+ textBox2.Text + "';", "Kundendaten");
                if (kunde == null)
                {
                    MessageBox.Show("felher");
                }
                else
                {
                    for (int i = 0; i < kunde.GetLength(0); i++)
                    {
                        if (textBox1.Text == kunde[i, 1] && textBox2.Text == kunde[i, 2])
                        {
                            kunden k = new kunden();

                            k.id = Convert.ToInt32(kunde[i, 0]);
                            k.Name = kunde[1, i];
                            k.Passwort = kunde[2, i];
                            //k.Admin = Convert.ToBoolean(kunde[2,i]);

                            main main = new main(this,k);
                            main.Show();
                            this.Hide();
                            break;
                        }
                    }
                }
                
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.CloseDatabase();
            Environment.Exit(0);
        }
    }
}
