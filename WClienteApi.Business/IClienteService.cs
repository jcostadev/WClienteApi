using System.Collections.Generic;
using WClienteApi.Domain;

namespace WClienteApi.Business {

    public interface IClienteService {

        void Insert(Cliente cliente);

        Cliente Get(int i);

        IEnumerable<Cliente> GetAll();

        void Delete(int id);

        void Update(Cliente cliente);
    }
}