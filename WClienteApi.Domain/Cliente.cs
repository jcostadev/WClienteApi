using MongoDB.Bson.Serialization.Attributes;

namespace WClienteApi.Domain {

    public class Cliente {
        //It tells MongoDB that ClientID is going to be used as unique key i.e. _id in client collection
        [BsonElement("_id")]
        public int ID { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string Ativo { get; set; }
    }
}