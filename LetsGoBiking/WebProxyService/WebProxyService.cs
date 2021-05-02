using System;

namespace WebProxyService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class WebProxyService : IWebProxyService
    {
        System.ServiceModel.Web.WebOperationContext ctx = System.ServiceModel.Web.WebOperationContext.Current;

        private ProxyCache<JCDecauxItem> cache = new ProxyCache<JCDecauxItem>();

        public Station GetStation(string id_contract)
        {
            ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "GET, PUT, POST, DELETE, HEAD, OPTIONS");

            return cache.Get(id_contract, 30).getStation();
        }
    }
}
