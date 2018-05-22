using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ApheliaGames.Backend
{
    public class MongoCollection
    {
        [BsonId]
        public ObjectId _id;
        [BsonRepresentation(BsonType.String)]
        public Guid _guid { get; set; }
    }
}
