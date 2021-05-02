using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebProxyService
{
    [DataContract]
    public class Position
    {
        [DataMember]
        public double lat { get; set; }

        [DataMember]
        public double lng { get; set; }

        public Position() { }

        public Position(double latitude,double longitude) {
            lat = latitude;
            lng = longitude;
        }

    }
}
