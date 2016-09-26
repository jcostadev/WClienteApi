using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WClienteApi.DataRepository {
    public interface IUnityOfWork {

        Repository Clientes { get; }
     
    }
}
