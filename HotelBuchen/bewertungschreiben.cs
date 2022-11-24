using System;
using System.Windows.Forms;

namespace HotelBuchen
{
    public partial class bewertungschreiben : Form
    {
        private Form1 _form;
        private Hotel info;
        private fulleintrag f;
        public bewertungschreiben(Form1 form,fulleintrag f, Hotel hotel)
        {
            InitializeComponent();
            _form = form;
            this.info = hotel;
            this.f = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(richTextBox1.Text))
            {
                _form.db.executequerey("Insert into Bewertungen(KID, WID, Bewertungen) Values(" + _form.kunde.id.ToString()+","+info.ID.ToString()+",'"+richTextBox1.Text+"')");
                f.getbewertungen();
                f.populatdatagridview();
                MessageBox.Show("Die Bewertung wurde abgeschickt");
                this.Close();
            }
            else
            {
                MessageBox.Show("Das Textfeld ist leer");
            }
        }
    }
}
