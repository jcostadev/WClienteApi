using System.Collections.Generic;
using WClienteApi.DataRepository;
using WClienteApi.Domain;

namespace WClienteApi.Business {

    /// <summary>
    /// Services to handle UnitOfWork Class
    /// </summary>
    public class ClienteService : IClienteService {
        private readonly UnitOfWork _cUnitOfwork;

        //It creates an instance of UnitOfWork class
        public ClienteService() {
        //instance of UnitOfWork class
            _cUnitOfwork = new UnitOfWork();
        }

        //Get method to get record on the basis of id
        public Cliente Get(int i) {
        // get record on the basis of id
            return _cUnitOfwork.Clientes.Get(i);
        }

        //Get all records 
        public IEnumerable<Cliente> GetAll() {
        //return all records
            return _cUnitOfwork.Clientes.GetAll();
        }

        //delete method to delete record on the basis of id
        public void Delete(int id) {
        //delete record on the basis of id
            _cUnitOfwork.Clientes.Delete(id);
        }

        //add method to insert an entity into collection
        public void Insert(Cliente cliente) {
        //insert an entity into collection
            _cUnitOfwork.Clientes.Add(cliente);
        }

        //update method to delete record on the basis of id
        public void Update(Cliente cliente) {
        //update to delete record on the basis of id
            _cUnitOfwork.Clientes.Update(cliente, cliente.ID);
        }
    }
}