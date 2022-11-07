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
                DataTable kunde = db.getItem("Select * from Kundendaten where Benutzername = '"+ textBox1.Text + "' and Passwort = '"+ textBox2.Text + "';");
                if (kunde == null)
                {
                    MessageBox.Show("felher");
                }
                
                MessageBox.Show(kunde.Rows.Count.ToString());
            }
        }
    }
}
