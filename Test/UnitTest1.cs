using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WClienteApi.Business;
using WClienteApi.DataRepository;


namespace Test {
    [TestClass]
    public class UnitTest1 {

        private IClienteService _clienteService;
        private IUnityOfWork _unitOfWork;
        private Repository _clienteRepository;

        private IMongoDatabase _dbEntities;

        private HttpClient _client;
        private HttpResponseMessage _response;

        private const string ServiceBaseURL = "http://localhost:4265/";

        

        [TestMethod]
        public void TestMethod1() {
            
            var unitOfWork = new Mock<IUnityOfWork>().Object;

            var mockService = new Moq.Mock<IClienteService>().Object;
            
        }
    }
}
