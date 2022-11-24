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
    public partial class regForm : Form
    {
        Form1 _form;
        public regForm(Form1 form)
        {
            InitializeComponent();
            _form = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) && textBox2.Text == textBox3.Text)
            {
                bool aaaaa = _form.db.isopen(textBox1.Text);
                if (!aaaaa)
                {
                    MessageBox.Show("Name ist schon vergeben");
                }
                else
                {
                    _form.db.executequerey("Insert into Kundendaten(Benutzername, Passwort) Values('"+textBox1.Text+"','"+textBox3.Text+"')");
                    MessageBox.Show("Konto erfolgreich erstellt");
                    this.Close();
                }
            }
        }
    }
}
