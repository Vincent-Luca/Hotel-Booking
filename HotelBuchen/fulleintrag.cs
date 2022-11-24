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
    public partial class fulleintrag : Form
    {

        private Hotel info;

        private Form1 _form;

        private List<Bewertung> bewetungen;

        public fulleintrag(Hotel info, Form1 form)
        {
            InitializeComponent();
            this.info = info;
            this._form = form;
            setinfo();
            List<Buchungen> temp = _form.db.GetBuchungen("SELECT DISTINCT (Buchungen.BID), Kundendaten.KID, Wohnungen.WID, Wohnungen.Namen, Kundendaten.Benutzername, Buchungen.Startdate, Buchungen.Enddate FROM Buchungen, Wohnungen, Kundendaten WHERE Kundendaten.KID = "+_form.kunde.id.ToString()+ " and Wohnungen.WID = "+info.ID.ToString()+" and Wohnungen.WID = Buchungen.WID AND  Kundendaten.KID = Buchungen.KID;");

            if (!(temp.Count == 0))
            {
                button2.Visible = true;
            }
            getbewertungen();
            populatdatagridview();
        }

        public void getbewertungen()
        {
            bewetungen = _form.db.GetBewertungs("Select distinct(BWID),Kundendaten.KID, Bewertungen.WID, Wohnungen.Namen, Kundendaten.Benutzername, Bewertungen.Bewertungen from Bewertungen, Kundendaten, Wohnungen where Bewertungen.WID = " + info.ID.ToString() + " and Kundendaten.KID = Bewertungen.KID AND Wohnungen.WID = Bewertungen.WID;");

        }

        public void populatdatagridview()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < bewetungen.Count; i++)
            {
                dataGridView1.Rows.Add(bewetungen[i].Name, bewetungen[i].bewertung);
            }
        }


        private void setinfo()
        {
            label2.Text = info.ID.ToString();
            label8.Text = info.Name;
            label9.Text = info.Ort;
            label10.Text = info.cost.ToString()+"€";

            checkBox1.Checked = info.familyfriendly;
            checkBox2.Checked = info.Wlan;
            checkBox3.Checked = info.Rauchen;
            checkBox4.Checked = info.Pets;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("Start datum ist nach oder am gleichen tag wie das End datum");
            }
            else if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                _form.db.executequerey("Insert into Buchungen(KID,WID,Startdate,Enddate) Values(" + _form.kunde.id.ToString() + "," + info.ID.ToString() + ",'"+ dateTimePicker1.Value.ToShortDateString().ToString() + "','"+ dateTimePicker2.Value.ToShortDateString().ToString() + "');");
                MessageBox.Show("Hotel gebucht!");
                this.Close();
            }
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = info.familyfriendly;
            checkBox2.Checked = info.Wlan;
            checkBox3.Checked = info.Rauchen;
            checkBox4.Checked = info.Pets;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Bewertung> temp = _form.db.GetBewertungs("SELECT DISTINCT (BWID) AS ers, Kundendaten.KID, Bewertungen.WID, Wohnungen.Namen, Kundendaten.Benutzername, Bewertungen.Bewertungen FROM Bewertungen, Kundendaten, Wohnungen WHERE (((Kundendaten.KID)=[Bewertungen].[KID]) AND Kundendaten.KID = "+_form.kunde.id+" AND ((Bewertungen.WID)="+info.ID+") AND ((Wohnungen.WID)=[Bewertungen].[WID]));\r\n");
            if (!(temp.Count == 0))
            {
                MessageBox.Show("Sie haben für dises Hotel schon eine Bewertung geschrieben");
            }
            else if (temp.Count == 0)
            {
                bewertungschreiben b = new bewertungschreiben(_form, this,this.info);
                b.Show();
            }
            else
            {
                MessageBox.Show("Ein fehler ist aufgetretten");
            }
        }
    }
}
