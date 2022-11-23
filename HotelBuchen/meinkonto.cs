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

        public meinkonto(kunden kunde, Form1 form)
        {
            InitializeComponent();
            this.kunde = kunde;
            this._form = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }
    }
}
