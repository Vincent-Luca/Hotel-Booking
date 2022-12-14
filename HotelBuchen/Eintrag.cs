using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBuchen
{
    public partial class Eintrag : Form
    {
        private Hotel infos;

        private Form1 _form;

        public Eintrag(Hotel infos, Form1 form)
        {
            InitializeComponent();
            this.infos = infos;
            label2.Text = infos.ID.ToString();
            label6.Text = infos.Ort.ToString();
            label4.Text = infos.Name.ToString();
            this._form = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fulleintrag f = new fulleintrag(infos, _form);
            f.Show();
        }
    }
}
