using BussinesLogic.implementation;
using BussinesLogic.interfaces;
using System.Web.Configuration;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace WebApplication
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
			var container = new UnityContainer();

            BussinesLogic.DepenFactory.Inicializate(WebConfigurationManager.AppSettings["conectionStringLiteDb"], 
                WebConfigurationManager.AppSettings["conectionStringDatabNotify"], WebConfigurationManager.AppSettings["dataBaseNotify"]);
            container.RegisterType<ISchema, Schema>();
            container.RegisterType<INotification, Notification>();
            container.RegisterType<ISchema, Schema>();

            return container;
        }
    }
}