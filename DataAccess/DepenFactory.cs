using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DataAccess
{
    public static class DepenFactory
    {
        public static IUnityContainer Container { get; set; }

        public static void Inicializate(String conectionString)
        {
            if(Container != null)
            {
                Container = new UnityContainer();
                Container.RegisterInstance("conectionString", conectionString);
            }           
        }

        public static T ResolveInstance<T>(string name="")
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
