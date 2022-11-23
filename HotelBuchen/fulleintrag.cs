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

        List<Bewertung> bewetungen;

        public fulleintrag(Hotel info, Form1 form)
        {
            InitializeComponent();
            this.info = info;
            this._form = form;
            setinfo();

            bewetungen = _form.db.GetBewertungs("Select distinct(BWID),Kundendaten.KID, Bewertungen.WID, Wohnungen.Namen, Kundendaten.Benutzername, Bewertungen.Bewertungen from Bewertungen, Kundendaten, Wohnungen where Bewertungen.WID = " + info.ID.ToString()+ " and Bewertungen.KID = Bewertungen.KID AND Wohnungen.WID = Bewertungen.WID;");
            populatdatagridview();
        }

        private void populatdatagridview()
        {
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
                _form.db.executequerey("Insert into Buchungen(KID,WID,Startdate,Enddate) Values(" + _form.kunde.id.ToString() + "," + info.ID.ToString() + ",'"+dateTimePicker1.Value.ToString()+ "','"+dateTimePicker2.Value.ToString()+"');");
            }
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = info.familyfriendly;
            checkBox2.Checked = info.Wlan;
            checkBox3.Checked = info.Rauchen;
            checkBox4.Checked = info.Pets;
        }
    }
}
