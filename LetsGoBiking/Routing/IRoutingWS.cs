using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace Routing
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IRoutingWS
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "?departPoint={departPoint}&arrivePoint={arrivePoint}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat =WebMessageFormat.Json)]
        Task<string> GetItinerarysAsync(string departPoint,string arrivePoint);

        [OperationContract]
        List<string> GetUtils();
    }
}
