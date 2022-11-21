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

        List<Hotel> hotels = new List<Hotel>();

        public main(Form1 form, kunden kunde)
        {
            InitializeComponent();
            _form = form;
            this.kunde = kunde;

            getAllHotels();
        }

        private void getAllHotels()
        {
            string[,] temp = _form.db.getItem("Select * from Wohnungen;", "Wohnungen");

            for (int i = 0; i < temp.GetLength(1); i++)
            {
                Hotel h = new Hotel();
                h.ID = int.Parse(temp[0, i]);
                h.Name = temp[1, i];
                h.Ort = temp[2, i];
                h.cost = int.Parse(temp[3, i]);
                h.familyfriendly = bool.Parse(temp[4, i]);
                h.Wlan = bool.Parse(temp[5, i]);
                h.Rauchen = bool.Parse(temp[6, i]);
                h.Pets = bool.Parse(temp[7,i]);
            }
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form.db.CloseDatabase();
            Environment.Exit(1);
        }
    }
}
