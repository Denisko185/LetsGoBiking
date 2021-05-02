using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebProxyService
{
    class JCDecauxItem
    {
         HttpClient client = new HttpClient();
         Station station;

        public JCDecauxItem() { }

        public JCDecauxItem(string parametre)
        {

            string[] subs = parametre.Split('_');
            station = getStAsync(subs[0],subs[1]).Result;
        }

        public async Task<Station> getStAsync(string numb,string contract)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations/"+numb+"?contract="+contract+"&apiKey=97fec324456625b67c705e9045722527dddb83b0");
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<Station>(response.Content.ReadAsStringAsync().Result);
                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }

        }

        public Station getStation()
        {
            return station;
        }
    }
}
