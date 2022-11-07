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
        private Databank db;

        public Databank DB{get{if (db == null){db = new Databank("Ferienwohnungen.mdb");}return db;}}



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text)&& !String.IsNullOrEmpty(textBox2.Text))
            {

            }
        }
    }
}
