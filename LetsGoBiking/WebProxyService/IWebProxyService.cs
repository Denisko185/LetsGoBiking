using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WebProxyService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IWebProxyService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "station?id_contract={id_contract}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        Station GetStation(string id_contract);

    }

}
