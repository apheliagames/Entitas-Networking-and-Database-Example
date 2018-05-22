using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ApheliaGames.Backend
{
    public class GameCollection : MongoCollection
    {
        public UserComponent user;
        public HealthComponent health;
    }
    
}


//Database extension for Entities of the Game Context
public sealed partial class GameEntity : Entitas.Entity
{
    [BsonId]
    public ObjectId _id;
    [BsonRepresentation(BsonType.String)]
    public Guid _guid { get; set; }
}

