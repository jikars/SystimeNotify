using DataAccess.implementation;
using DataAccess.interfaces;
using SchemaDataBase.implementation;
using SchemaDataBase.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BussinesLogic
{
    public static class DepenFactory
    {
        public static IUnityContainer Container { get; set; }

        public static void Inicializate(String conectionStringLiteDb,String conectionStringDatabaseNotificate, String databaseName)
        {
            if (Container != null)
            {
                DataAccess.DepenFactory.Inicializate(conectionStringLiteDb);
                Container.RegisterInstance("dataBase", databaseName);
            }
        }

        public static T ResolveInstance<T>(string name = "")
        {
            if (!String.IsNullOrEmpty(name))
            {
                return Container.Resolve<T>(name);
            }
            else
            {
                return Container.Resolve<T>();
            }
        }
    }
}
