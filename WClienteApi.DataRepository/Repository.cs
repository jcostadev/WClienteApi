using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using WClienteApi.Domain;

namespace WClienteApi.DataRepository {

    public class Repository: IRepository<Cliente>{

        //It declares the variable that will contain an instance of the MongoClient class
        protected static IMongoClient _client;

        //It declares the variable that will contain an instance of the database
        protected static IMongoDatabase _database;

        //It declares the variable that will contain an instance of the collection
        protected static IMongoCollection<Cliente> _collection;

        // constructor to initialise database and table/collection
        public Repository(IMongoClient client, string tblName, string collName) {

            //initialize _cliente with an instance of MongoClient
            _client = client;

            //initialize _database with an instance of Database
            _database = _client.GetDatabase(tblName);

            //initialize _collection with an instance of Collection
            _collection = _database.GetCollection<Cliente>(collName);
        }

        /// <summary>
        /// Generic add method to insert enities to collection
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Cliente entity) {

            //inserts entity of type T into collection
            _collection.InsertOne(entity);
        }

        /// <summary>
        /// Generic Get method to get record on the basis of id
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Cliente Get(int id) {
            //searches for an entity of type T by id
            var data = _collection.Find<Cliente>(x => x.ID == id);

            //var data = _collection.Find<T>(x => x.ID == id);

            //return the first result
            return data?.First();
        }

        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cliente> GetAll() {

            //It creates an empty filter of type JsonFilterDefinition<T> class
            var filter = new JsonFilterDefinition<Cliente>("{}");

            //It searches for a record with the property of filter
            var t = _collection.Find<Cliente>(filter);

            //It returns a new list of type T. It is equivalent to using "new List<T>(instance)".
            var data = t.ToList<Cliente>();

            //It returns the enumerable fo type T
            return data;
        }

        /// <summary>
        /// Generic delete method to delete record on the basis of id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id) {

            //It creates a filter based on the expression 
            var filter = Builders<Cliente>.Filter.Where(e => e.ID == id);
            
            //It deletes a record  
            _collection.DeleteOne(filter);
        }

        /// <summary>
        ///  Generic update method to delete record on the basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public void Update(Cliente entity, int id) {

            //It creates a filter based on the expression 
            var filter = Builders<Cliente>.Filter.Where(e => e.ID == id);

            //It updates method to delete record on the basis of id
            var update = _collection.ReplaceOne(filter, entity);
        }
    }
}