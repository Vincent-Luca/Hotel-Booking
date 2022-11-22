using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBuchen
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Ort { get; set; }
        public int cost { get; set; }
        public bool familyfriendly { get; set; }
        public bool Wlan { get; set; }
        public bool Rauchen { get; set; }
        public bool Pets { get; set; }
    }
}
