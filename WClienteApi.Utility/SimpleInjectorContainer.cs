using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using WClienteApi.Business;
using WClienteApi.DataRepository;
using WClienteApi.Domain;
using MongoDB.Driver;

namespace WClienteApi.Utility {
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices() {

           //creatring a simple injector container
           var container = new Container();

           //container.Register is used here to register the service IClienteService and its implementation ClienteService
           container.Register<IClienteService, ClienteService>();

            //container.Register is used here to register the service IUnityOfWork and its implementation UnitOfWork
            container.Register<IUnityOfWork, UnitOfWork>();
        
            return container;
        }
    }
}
