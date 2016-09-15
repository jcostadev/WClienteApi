using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using WClienteApi.Business;

namespace WClienteApi.Utility {
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices() {

           var container = new Container();

           container.Register<IClienteService, ClienteService>();

           container.Verify();

           return container;
        }
    }
}
