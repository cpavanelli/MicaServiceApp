using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MicaWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMicaService" in both code and config file together.
    [ServiceContract]
    public interface IMicaService
    {
        [OperationContract]
        [WebGet(UriTemplate = "Restaurantes", ResponseFormat = WebMessageFormat.Json)]
        Restaurante[] GetRestaurantes();

        [OperationContract]
        [WebInvoke(Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "SaveRestaurante/{id}")]
        string SaveRestaurante(Restaurante restaurante, string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "DeleteRestaurante")]
        bool DeleteRestaurante(Restaurante restaurante);

        [OperationContract]
        [WebGet(UriTemplate = "Medias", ResponseFormat = WebMessageFormat.Json)]
        Media [] GetMedias();

        [OperationContract]
        [WebInvoke(Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "SaveMedia /{id}")]
        string SaveMedia (Media  media , string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "DeleteMedia ")]
        bool DeleteMedia (Media media );

        [OperationContract]
        [WebGet(UriTemplate = "Eventos", ResponseFormat = WebMessageFormat.Json)]
        Evento[] GetEventos();

        [OperationContract]
        [WebInvoke(Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "SaveEvento/{id}")]
        string SaveEvento(Evento evento, string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "DeleteEvento")]
        bool DeleteEvento(Evento evento);


        [OperationContract]
        [WebGet(UriTemplate = "DashItems", ResponseFormat = WebMessageFormat.Json)]
        DashItem[] GetDash();

        [OperationContract]
        [WebGet(UriTemplate = "GetNextEvents", ResponseFormat = WebMessageFormat.Json)]
        DashItem[] GetNextEvents();
    }
}
