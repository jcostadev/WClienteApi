using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WClienteApi.Business;
using WClienteApi.Domain;

namespace WClienteApi.Controllers {

    public class ClienteController : ApiController {

        //It declares the variable that will contain ClienteService instance 
        private readonly IClienteService _clienteService;

        //It declares the variable that will contain HttpStatusCode instance 
        private HttpStatusCode status;

        //injecting a dependency from the Constructor
        public ClienteController(IClienteService clienteService) {
            //instance of ClienteService
            _clienteService = clienteService;

            //It creates an instance of HttpStatusCode
            status = new HttpStatusCode();
        }

        /// <summary>
        /// It adds a record
        /// </summary>
        /// <param name="cliente"></param>
        ///[FromBody]: It is used to force Web API to read a simple type from the request body
        public IHttpActionResult Post([FromBody]Cliente cliente) {

            try {
                //if the parameter is not null, insert it in the database
                if (cliente != null) _clienteService.Insert(cliente);

                //It sets HttpStatusCode.Ok to the variable status
                status = HttpStatusCode.OK;
            } catch {
                //It sets HttpStatusCode.InternalServerError to the variable status
                status = HttpStatusCode.InternalServerError;
            }

            //Appends the specified string to the file, creating the file if it does not already exist 
            File.AppendAllText(@"C:\message\file.txt", status.ToString() + " " + DateTime.Now.ToString() + Environment.NewLine);

            //It returns a message of the type IHttpActionResult with the specified parameters
            return ResponseMessage(Request.CreateResponse(status, status.ToString()));
        }

        /// <summary>
        /// It returns a client from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id) {

            try {

                //Get method to get record on the basis of id
                var cliente = _clienteService.Get(id);

                //
                if (cliente != null) status = HttpStatusCode.OK;

                //It returns a message of the type IHttpActionResult with the specified parameters
                return ResponseMessage(Request.CreateResponse<Cliente>(status, cliente));
            } catch (Exception e) {

                //set a value to the variable status
                status = HttpStatusCode.InternalServerError;

                //Appends the specified string to the file, creating the file if it does not already exist 
                File.AppendAllText(@"C:\message\file.txt", " - " + status.ToString() + " " + e.ToString() + " " + DateTime.Now.ToString() + Environment.NewLine);
            }

            //It returns a message of the type IHttpActionResult with the specified parameters
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "HttpStatusCode.InternalServerError"));
        }

        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll() {
            try {

                //Get all records
                var cliente = _clienteService.GetAll();

                //Any() will return true if there are any objects in the IEnumerable since it will return true if it makes it past the first object. 
                if (cliente.Any())
                    //It returns a message of the type IHttpActionResult with the specified parameters
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, cliente));
            } catch (Exception e) {

                //set a value to the variable status
                status = HttpStatusCode.InternalServerError;

                //Appends the specified string to the file, creating the file if it does not already exist 
                File.AppendAllText(@"C:\message\file.txt", " - " + status.ToString() + " " + e.ToString() + " " + DateTime.Now.ToString() + Environment.NewLine);
            }

            //It returns a message of the type IHttpActionResult with the specified parameters
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "HttpStatusCode.InternalServerError"));
        }

        /// <summary>
        ///  update method to delete record on the basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        /// [FromBody]: It is used to force Web API to read a simple type from the request body
        public IHttpActionResult Put(int id, [FromBody]Cliente cliente) {

            try {
                //It determines if the client is not null
                if (cliente != null) {
                    //update method to delete record on the basis of id
                    _clienteService.Update(cliente);
                    //set a value to the variable status
                    status = HttpStatusCode.OK;
                }
            } catch {

                //set a value to the variable status
                status = HttpStatusCode.InternalServerError;

                //Appends the specified string to the file, creating the file if it does not already exist 
                File.AppendAllText(@"C:\message\file.txt", status.ToString() + " " + DateTime.Now.ToString() + Environment.NewLine);
            }

            //It returns a message of the type IHttpActionResult with the specified parameters
            return ResponseMessage(Request.CreateResponse(status, status.ToString()));
        }

        /// <summary>
        ///  delete record on the basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id) {

            //Get method to get record on the basis of id
            var cliente = _clienteService.Get(id);

            try {
                if (cliente != null) {

                    // delete record on the basis of id
                    _clienteService.Delete(id);

                    //set a value to the variable status
                    status = HttpStatusCode.OK;
                }
            } catch {
                //Appends the specified string to the file, creating the file if it does not already exist
                File.AppendAllText(@"C:\message\file.txt", status.ToString() + " " + DateTime.Now.ToString() + Environment.NewLine);

                //set a value to the variable status
                status = HttpStatusCode.InternalServerError;
            }

            //It returns a message of the type IHttpActionResult with the specified parameters
            return ResponseMessage(Request.CreateResponse(status, status.ToString()));
        }
    }
}