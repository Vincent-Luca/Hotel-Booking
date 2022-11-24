using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBuchen.Datasets
{
    public class Buchungen
    {
        public readonly int BID;

        public readonly int KID;

        public readonly int WID;

        public readonly string WName;

        public readonly string KName;

        public readonly string startdatum;

        public readonly string enddatum;

        public Buchungen(int BID, int KID, int WID, string WName, string Kname, string startdatum, string enddatum)
        {
            this.BID = BID;
            this.KID = KID;
            this. WID = WID;
            this.WName = WName;
            this.KName = Kname;
            this.startdatum = startdatum;
            this.enddatum = enddatum;
        }
    }
}
