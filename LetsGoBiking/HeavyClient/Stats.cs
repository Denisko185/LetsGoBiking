using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyClient
{
    public class Stats
    {
        public List<double> departPoint { get; set; }
        public List<double> arrivePoint { get; set; }
        public string departStationName { get; set; }
        public string arriveStationName { get; set; }
        public double distance { get; set; }
        public double duration { get; set; }
        public string dateHeure { get; set; }
    }

}
