using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HotelBuchen.Datasets
{
    public class Bewertung
    {
        public readonly int BWID;

        public readonly int KID;

        public readonly int WID;

        public readonly string WName;

        public readonly string Name;

        public readonly string bewertung;

        public Bewertung(int BWID, int kid, int wid,string Wname, string name, string bewertung)
        {
            this.BWID = BWID;
            this.KID = kid;
            this.WID = wid;
            this.WName = Wname;
            this.Name = name;
            this.bewertung = bewertung;
        }

    }
}
