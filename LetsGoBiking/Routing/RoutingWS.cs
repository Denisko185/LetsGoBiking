using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Globalization;
using System.ServiceModel.Web;
using System.ServiceModel;

namespace Routing
{
    public class RoutingWS : IRoutingWS
    {
        List<Station> stations = null; //JsonConvert.DeserializeObject<Station[]>(responseBody);
        string docPath ;


        public RoutingWS()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }


        /**
         * Cette methode , implementation de l'interface renvoit un tring, list les itineraires à suivre par l'utilisateur
         * Si la station de depart est la meme que celle d'arrivé ou si la distance separant le point d'arrivé et le point de
         *          depart est inferieur à la distance entre le point de depart et la station de depart elle renvoie un intineraire unique à pieds
         * Si la distance ou la durée separant le point d'arrivé et le point de depart est inferieur à la distance entre le point de depart et la station de depart plus la station d'arrivée et le point d'arrivée
         *      elle renvoie un itinerair à pieds
         * Sinon deux inteneraires à pieds et un à velo
         * 
         * */
        public async Task<string> GetItinerarysAsync(string departPoint, string arrivePoint)
        {
            Station departStation, arriveStation;
            string[] subs1 = departPoint.Split(',');
            string[] subs2 = arrivePoint.Split(',');
            List<Itinerary> itineraires = new List<Itinerary>();

            if (stations == null)
                stations = JsonConvert.DeserializeObject<List<Station>>(getStAsync().Result);
            double d1 = Convert.ToDouble(subs1[0], new CultureInfo("en-US"));
            double d2 = Convert.ToDouble(subs1[1], new CultureInfo("en-US"));
            double d3 = Convert.ToDouble(subs2[0], new CultureInfo("en-US"));
            double d4 = Convert.ToDouble(subs2[1], new CultureInfo("en-US"));

            departStation = getValideNearStation(d2, d1);
            //à suivre
            arriveStation = getValideNearStation(d4, d3);
            double x = computeDistance(d2, d1, d4, d3);
            double y = computeDistance(d2, d1, departStation.position.lat, departStation.position.lng);

            if (departStation.name.Equals(arriveStation.name) || x < y)
            {
                itineraires.Add(JsonConvert.DeserializeObject<Itinerary>(getItinerary(departPoint, arrivePoint, "foot-walking")));
            }
            else
            {
                List<Itinerary> itinerairestmp1 = new List<Itinerary>();
                List<Itinerary> itinerairestmp2 = new List<Itinerary>();

                itinerairestmp1.Add(JsonConvert.DeserializeObject<Itinerary>(getItinerary(departPoint, arrivePoint, "foot-walking")));

                string s = departStation.position.lng.ToString().Replace(",", ".") + "," + departStation.position.lat.ToString().Replace(",", ".");
                itinerairestmp2.Add(JsonConvert.DeserializeObject<Itinerary>(getItinerary(departPoint, s, "foot-walking")));
                itinerairestmp2.Add(JsonConvert.DeserializeObject<Itinerary>(getItinerary(departStation.position.lng.ToString().Replace(",", ".") + "," + departStation.position.lat.ToString().Replace(",", "."), arriveStation.position.lng.ToString().Replace(",", ".") + "," + arriveStation.position.lat.ToString().Replace(",", "."), "cycling-road")));
                itinerairestmp2.Add(JsonConvert.DeserializeObject<Itinerary>(getItinerary(arriveStation.position.lng.ToString().Replace(",", ".") + "," + arriveStation.position.lat.ToString().Replace(",", "."), arrivePoint, "foot-walking")));

                if(itinerairestmp1[0].features[0].properties.summary.distance < (itinerairestmp2[0].features[0].properties.summary.distance+ itinerairestmp2[2].features[0].properties.summary.distance) ||
                                itinerairestmp1[0].features[0].properties.summary.duration < (itinerairestmp2[0].features[0].properties.summary.duration + itinerairestmp2[2].features[0].properties.summary.duration + itinerairestmp2[1].features[0].properties.summary.duration))
                {
                    itineraires = itinerairestmp1;
                }
                else
                {
                    itineraires = itinerairestmp2;
                }

            }

            TextWriter sr = new StreamWriter(Path.Combine(docPath, "itineraires.json"), true);

            if (itineraires.Count == 1) { 
                sr.WriteLine("{"+string.Format("\"departPoint\":[{0}],\"arrivePoint\":[{1}],\"departStationName\":\"{2}\",\"arriveStationName\":\"{3}\",\"distance\":{4},\"duration\":{5}, \"dateHeure\":\"{6}\"",
                    departPoint, arrivePoint, "NaN", "NaN", itineraires[0].features[0].properties.summary.distance.ToString().Replace(",", "."), itineraires[0].features[0].properties.summary.duration.ToString().Replace(",", "."), DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")) + "}");
              //  sr.WriteLine();
            }
            if (itineraires.Count > 1) {
                double dst = itineraires[0].features[0].properties.summary.distance + itineraires[1].features[0].properties.summary.distance + itineraires[2].features[0].properties.summary.distance;
                double dur = itineraires[0].features[0].properties.summary.duration + itineraires[1].features[0].properties.summary.duration + itineraires[2].features[0].properties.summary.duration;

                sr.WriteLine("{" + string.Format("\"departPoint\":[{0}],\"arrivePoint\":[{1}],\"departStationName\":\"{2}\",\"arriveStationName\":\"{3}\",\"distance\":{4},\"duration\":{5}, \"dateHeure\":\"{6}\"",
                    departPoint, arrivePoint, departStation.name, arriveStation.name, dst.ToString().Replace(",","."), dur.ToString().Replace(",", "."), DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")) + "}");
               // sr.WriteLine();
            }
            sr.Close();
           //// fs.Close();

            return JsonConvert.SerializeObject(itineraires);
        }

        public List<string> GetUtils()
        {
            TextReader sr = new StreamReader(Path.Combine(docPath, "itineraires.json"), true);
            string Line;
            List<string> lst = new List<string>();
            while ((Line = sr.ReadLine()) != null)
            {
                lst.Add(Line);
            }
            return lst;
        }


        /**
         * methode permettant de recuperer la station la plus proche avec des velos disponibles
         */
        private Station getValideNearStation(double latit, double longit)
        {
            Station val, stationdistante;
            List <Station> st = (List <Station>)stations;
            val = getNearStation(latit, longit, st);
            string b = GetStationfomUrlAsync(val.number, val.contract_name).Result;
            stationdistante = JsonConvert.DeserializeObject<Station>(b);
            while (stationdistante.available_bikes < 1)
            {
                st = st.Where((source) => source != val).ToList();
                val = getNearStation(latit, longit, st);
                stationdistante = JsonConvert.DeserializeObject<Station>(GetStationfomUrlAsync(val.number, val.contract_name).Result);
            }
            return stationdistante;

        }


        /**
         * methode permettant de recuperer la station la plus proche 
         */
        private Station getNearStation(double latit, double longit, List<Station> st)
        {
            double dist = computeDistance(latit,longit, st[0].position.lat, st[0].position.lng);
            Station plusproch = st[0];
            foreach(Station s in st) {
                double tmp = computeDistance(latit, longit, s.position.lat, s.position.lng);
                if (dist> tmp)
                {
                    plusproch = s;
                    dist = tmp;
                }
            }
            return plusproch;

        }

        /**
         * Methode permettant de calculer la distance entre deux points
         */
        private double computeDistance(double latit, double longit, double lat, double lng)
        {

            double deltaX = ((longit - lng) *
                    Math.Cos((latit + lat) / 2));
            double deltaY = latit - lat;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }


        /**
         * Methode pemettant de recuperer une station depuis le webproxy distant
         */
        private async Task<string> GetStationfomUrlAsync(int id,string contract)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://localhost:8733/Design_Time_Addresses/WebProxyService/Service1/rest/station?id_contract=" + id + "_" + contract);
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return "Exception Caught";
            }
        }

        /**
         * Methode pemettant de recuperer une station depuis l'Api JcDecaux
         */
        public async Task<string> getStAsync()
        {
            HttpClient client = new HttpClient();
            string a = "Exception Caught";
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations?&apiKey=97fec324456625b67c705e9045722527dddb83b0");
                response.EnsureSuccessStatusCode();
                a = response.Content.ReadAsStringAsync().Result;
                //return  a;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                //return "Exception Caught";
            }
            return a;

        }


        /**
         * Methode pemettant de recuperer un itineraire depuis openrouteservice
         */
        private string getItinerary(string depart, string arrive,string type)
        {
            HttpClient client = new HttpClient();
            // Itinerary dir = null;

            string url = "https://api.openrouteservice.org/v2/directions/" + type + "?api_key=5b3ce3597851110001cf6248cf9f4d62eee94d5a9865e7436727b5d9&start=" + depart + "&end=" + arrive;

            try
            {
                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
                using (var respons = webrequest.GetResponse())
                using (var reader = new StreamReader(respons.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    return result;
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return "Exception lors de la recuperation de l'itineraire";
            }

        }


    }
}
