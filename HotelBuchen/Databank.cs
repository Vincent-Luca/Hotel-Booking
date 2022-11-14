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
            _command = new OleDbCommand();

            if (!Directory.Exists(dir))
            {
                MessageBox.Show(dir);
                MessageBox.Show("Datenbank existiert nicht");
            }
            else
            {
                dir = Path.Combine(dir, datenbankName);
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dir);
                _command.Connection = con;
                con.Open();
            }
        }

        public string[,] getColumnNames(string table)
        {

            _command.CommandText = "Select * from " + table + ";";
            reader = _command.ExecuteReader();
            string[,] temp = new string[2,reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
            {
                temp[0,i] = reader.GetName(i);
                temp[1,i] = reader.GetFieldType(i).ToString();
            }
            reader.Close();
            return temp;
        }

        public string[,] getItem(string SQLAbfrage, string table)
        {
            _command.CommandText = "Select COUNT(*) from " + table + ";";
            int rowcount = 0;
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                rowcount = Convert.ToInt32(reader.GetValue(0));
            }
            reader.Close();



            _command.CommandText = SQLAbfrage;
            reader = _command.ExecuteReader();
            string[,] temp = new string[rowcount, reader.FieldCount];
            int j = 0;
            while (reader.Read())
            {
                for (int i = 0; i < temp.GetLength(1); i++)
                {
                    temp[j, i] = reader.GetValue(i).ToString();
                }
                j++;
            }

            reader.Close();
            return temp;
        }


        public void CloseDatabase()
        {
            _command.Connection.Close();
            con.Close();
        }
    }
}
