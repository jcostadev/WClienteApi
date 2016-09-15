using MongoDB.Driver;
using WClienteApi.Domain;

namespace WClienteApi.DataRepository {

    /// <summary>
    /// It establishes connection with the MongoDB Server and returns the Repository as its property.
    /// </summary>
    public class UnitOfWork {

        //It declares the variable that will contain Repository of type Cliente
        protected Repository<Cliente> _clienteRepository;

        //It declares the variable that will contain an instance of the MongoClient class
        private IMongoClient _client;

        public UnitOfWork() {
            //Initializes a new instance of the MongoClient class
            _client = new MongoClient();
        }

        //It returns an instance of Repository class
        public Repository<Cliente> Clientes {
            get {
                //tests if _cliente is not equal to null
                if (_clienteRepository == null)
                    //It creates a repository of type Cliente, defines the name of the database and collection
                    _clienteRepository = new Repository<Cliente>(_client, "Cliente", "Pessoa");

                //returns cliente Repository
                return _clienteRepository;
            }
        }
    }
}