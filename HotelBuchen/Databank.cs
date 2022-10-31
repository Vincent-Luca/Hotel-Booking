using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBuchen
{
    internal class Databank
    {
        string workingDirectory = Environment.CurrentDirectory;
        string dir;
        OleDbConnection con;
        public OleDbCommand Command;
        public Databank()
        {
            dir = Directory.GetParent(workingDirectory).Parent.FullName;
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dir + "\\Ferienwohnungen.mdb");
        }
    }
}
