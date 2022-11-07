using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBuchen
{
    public class Databank
    {
        private readonly string workingDirectory = Environment.CurrentDirectory;
        private string dir;
        private readonly OleDbConnection con;
        private readonly OleDbCommand _command;
        private OleDbDataReader reader;
        public Databank(string datenbankName)
        {
            dir = Directory.GetParent(workingDirectory).Parent.FullName;
            dir = Path.Combine(dir, datenbankName);

            //E:\codeprojects\schoolprojects\hotelseite\HotelBuchen\Hotel-Booking\HotelBuchen\Ferienwohnungen.mdb

            if (!Directory.Exists(dir))
            {
                MessageBox.Show(dir);
                MessageBox.Show("Datenbank existiert nicht");
            }
            else
            {
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dir);
                _command.Connection = con;
            }
        }


        public DataTable getItem(string SQLAbfrage)
        {
            _command.CommandText = SQLAbfrage;
            reader = _command.ExecuteReader();
            DataTable dt = new DataTable();
            dt = reader.GetSchemaTable();
            reader.Close();
            return dt;
        }


        public void CloseDatabase()
        {
            _command.Connection.Close();
            con.Close();
        }
    }
}
