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
            setpage(hotels);

            label2.Text = (aufSeite + 1).ToString();
        }

        private int numberOfMaxPages(List<Hotel> Liste)
        { 
            if(Liste == null) return 0;

            double count = Liste.Count;
            count = Math.Round(count/2);
            return Convert.ToInt32(count);
        }


        private void setpage(List<Hotel> Liste)
        {
            for (int i = 0; i < panels.Count; i++)
            {
                panels[i].Controls.Clear();
            }
            try
            {
                for (int i = 0; i < panels.Count; i++)
                {
                    if ((aufSeite * 2) + i >= hotels.Count)
                    {
                        break;
                    }
                    Eintrag E = new Eintrag(Liste[(aufSeite * 2) + i], _form) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    panels[i].Controls.Clear();
                    panels[i].Controls.Add(E);
                    E.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ein fehler ist aufgetretten, bitte versuchen sie es später noch einmal");
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
            else if (aufSeite > 0 && searchresult == null)
            {
                aufSeite--;
                setpage(hotels);
                label2.Text = (aufSeite + 1).ToString();
            }
            else if (aufSeite > 0 && searchresult != null)
            {
                aufSeite--;
                setpage(searchresult);
                label2.Text = (aufSeite + 1).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (aufSeite + 1 == numberOfMaxPages(hotels) || aufSeite + 1 == numberOfMaxPages(searchresult))
            { }
            else if (aufSeite < numberOfMaxPages(hotels) && searchresult == null)
            {
                aufSeite++;
                setpage(hotels);
                label2.Text = (aufSeite + 1).ToString();
            }
            else if (aufSeite < numberOfMaxPages(searchresult) && searchresult != null)
            {
                aufSeite++;
                setpage(searchresult);
                label2.Text = (aufSeite + 1).ToString();
            }
        }



        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form.db.CloseDatabase();
            Environment.Exit(1);
        }


        public List<Hotel> Searchtags(string tag, List<Hotel> currentsearchresuls = null)
        {
            if (currentsearchresuls != null)
            {
                switch (tag)
                {
                    case "Pets":
                        return currentsearchresuls.FindAll(x => x.Pets == true);

                    case "familyfriendly":
                        return currentsearchresuls.FindAll(x => x.familyfriendly == true);

                    case "Wlan":
                        return currentsearchresuls.FindAll(x => x.Wlan == true);

                    case "Rauchen":
                        return currentsearchresuls.FindAll(x => x.Rauchen == true);

                    case "costsup":
                        return currentsearchresuls.OrderBy(x => x.cost).ToList();

                    case "costsdown":
                        return currentsearchresuls.OrderByDescending(x => x.cost).ToList(); ;

                    default:
                        return null;
                }
            }
            else
            {
                switch (tag)
                {
                    case "Pets":
                        return hotels.FindAll(x => x.Pets == true);

                    case "familyfriendly":
                        return hotels.FindAll(x => x.familyfriendly == true);

                    case "Wlan":
                        return hotels.FindAll(x => x.Wlan == true);

                    case "Rauchen":
                        return hotels.FindAll(x => x.Rauchen == true);

                    case "costsup":
                        return hotels.OrderBy(x => x.cost).ToList();

                    case "costsdown":
                        return hotels.OrderByDescending(x => x.cost).ToList();

                    default:
                        return null;
                }
            }
        }


        private void radioButton_Click(object sender, EventArgs e)
        {
            aufSeite = 0;
            RadioButton r = (RadioButton)sender;
            searchresult = Searchtags(r.Tag.ToString(), searchresult);
            setpage(searchresult);
            label2.Text = (aufSeite + 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            searchresult = null;
            aufSeite = 0;
            foreach (Control clt in Controls)
            {
                if (clt is RadioButton)
                {
                    RadioButton chk = (RadioButton)clt;
                    chk.Checked = false;
                }
                else
                {
                    continue;
                }
            }
            numberOfMaxPages(hotels);
            setpage(hotels);
            label2.Text = (aufSeite + 1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            meinkonto m = new meinkonto(kunde, _form, this);
            m.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            _form.Show();
        }
    }
}
