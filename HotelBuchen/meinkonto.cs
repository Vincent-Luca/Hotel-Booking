using HotelBuchen.Datasets;
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
    public partial class meinkonto : Form
    {
        private kunden kunde;
        private Form1 _form;
        private bool passopen = false;

        public meinkonto(kunden kunde, Form1 form)
        {
            InitializeComponent();
            this.kunde = kunde;
            this._form = form;

            List<Bewertung> bewertung = _form.db.GetBewertungs("Select distinct(BWID),Kundendaten.KID, Bewertungen.WID, Wohnungen.Namen, Kundendaten.Benutzername, Bewertungen.Bewertungen from Bewertungen, Kundendaten, Wohnungen where Kundendaten.KID = "+kunde.id.ToString()+" and Kundendaten.KID = Bewertungen.KID AND Wohnungen.WID = Bewertungen.WID;");
            populatebewertungen(bewertung);
            List<Buchungen> buchungens = _form.db.GetBuchungen("Select Distinct(Buchungen.BID), Kundendaten.KID, Wohnungen.WID, Wohnungen.Namen , Kundendaten.Benutzername, Buchungen.Startdate, Buchungen.Enddate From Buchungen, Wohnungen, Kundendaten Where Kundendaten.KID = "+kunde.id.ToString()+" and Wohnungen.WID = Buchungen.WID;");
            populatebuchungen(buchungens);
            
            passwordchar();
            label12.Text = kunde.id.ToString();
            label13.Text = kunde.Name;
        }

        private void passwordchar()
        {
            string passchar = "*";
            for (int i = 1; i < kunde.Passwort.Length; i++)
            {
                passchar += "*";
            }
            label14.Text = passchar;
        }

        private void populatebewertungen(List<Bewertung> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                dataGridView2.Rows.Add(list[i].WName, list[i].bewertung);
            }
        }

        private void populatebuchungen(List<Buchungen> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                dataGridView1.Rows.Add(list[i].WName, list[i].startdatum +" - "+list[i].enddatum);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            button1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) && textBox1.Text == kunde.Name && textBox3.Text == kunde.Passwort)
            {
                _form.db.executequerey("Update Kundendaten Set Benutzername = '"+textBox2.Text+"' where KID = "+kunde.id+";");

                
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                panel1.Hide();
                button2.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrEmpty(textBox6.Text) && textBox4.Text == kunde.Passwort && textBox5.Text == textBox6.Text)
            {
                _form.db.executequerey("Update Kundendaten Set Passwort = '" + textBox2.Text + "' where KID = " + kunde.id + ";");


                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                panel2.Hide();
                button1.Visible = true;
            }
        }

        private void meinkonto_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form.db.CloseDatabase();
            Environment.Exit(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (passopen == false)
            {
                label14.Text = kunde.Passwort;
                passopen = true;
            }
            else if (passopen)
            {
                passwordchar();
                passopen = false;
            }
        }
    }
}
