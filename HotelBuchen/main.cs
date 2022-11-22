using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBuchen
{
    public partial class main : Form
    {
        private Form1 _form = null;

        private kunden kunde = null;

        private List<Hotel> hotels = new List<Hotel>();

        private List<Hotel> searchresult;

        private List<Panel> panels;

        private int aufSeite = 0;

        public main(Form1 form, kunden kunde)
        {
            InitializeComponent();
            _form = form;
            this.kunde = kunde;
            panels = new List<Panel> { panel2, panel3 };

            getAllHotels();
            setpage();

            label2.Text = (aufSeite + 1).ToString();
        }

        private int numberOfMaxPages()
        {
            double count = hotels.Count;
            count = Math.Round(count/2);
            return Convert.ToInt32(count);
        }


        private void setpage()
        {
            for (int i = 0; i < panels.Count; i++)
            {
                panels[i].Controls.Clear();
            }

            for (int i = 0; i < panels.Count; i++)
            {
                if ((aufSeite * 2) + i >= hotels.Count)
                {
                    break;
                }
                Eintrag E = new Eintrag(hotels[(aufSeite * 2) + i]) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panels[i].Controls.Clear();
                panels[i].Controls.Add(E);
                E.Show();
            }
        }

        private void getAllHotels()
        {
            string[,] temp = _form.db.getItem("Select * from Wohnungen;", "Wohnungen");

            for (int i = 0; i < temp.GetLength(0); i++)
            {
                Hotel h = new Hotel();
                h.ID = int.Parse(temp[i, 0]);
                h.Name = temp[i, 1];
                h.Ort = temp[i, 2];
                h.cost = Int32.Parse(temp[i, 3]);
                h.familyfriendly = bool.Parse(temp[i, 4]);
                h.Wlan = bool.Parse(temp[i, 5]);
                h.Rauchen = bool.Parse(temp[i, 6]);
                h.Pets = bool.Parse(temp[i,7]);
                hotels.Add(h);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (aufSeite == 0)
            { }
            else if (aufSeite > 0)
            {
                aufSeite--;
                setpage();
                label2.Text = (aufSeite + 1).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (aufSeite + 1 == numberOfMaxPages())
            { }
            else if (aufSeite < numberOfMaxPages())
            {
                aufSeite++;
                setpage();
                label2.Text = (aufSeite + 1).ToString();
            }
        }



        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form.db.CloseDatabase();
            Environment.Exit(1);
        }
    }
}
