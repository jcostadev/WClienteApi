using System.Web.Http;
using System.Web.Configuration;
using WClienteApi.Utility;
using WClienteApi.Business;
using SimpleInjector;

namespace WClienteApi {

    public class WebApiApplication : System.Web.HttpApplication {

        protected void Application_Start() {

       
             GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}