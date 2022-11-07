using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
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
            if (!Directory.Exists(dir))
            {
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
            _command.CommandText = "";
            reader = _command.ExecuteReader();
            DataTable dt = new DataTable();
            dt = reader.GetSchemaTable();
            reader.Close();
            return dt;
        }
    }
}
