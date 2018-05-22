using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace ApheliaGames.Backend
{
    /// <summary>
	/// Author: Robert Klausch @ ApheliaGames
    /// This class is connecting to the MongoDB database with the specified URL and port
    /// initializing all needed collections and make them public to the controllers
    /// </summary>

    public class MongoDBController : MonoBehaviour
    {
        public string mongodbURL = "localhost";
        public string mongodbPort = "3001";
        MongoClient client;
        MongoServer server;
        public MongoDatabase database;
        public MongoCollection<GameEntity> game;
        public MongoCollection<GameCollection> gamedata;

        // Use this for initialization
        private void Start()
        {
            string _databaseconnection = "mongodb://" + mongodbURL + ":" + mongodbPort;
            Debug.Log("Connecting the database on: " + _databaseconnection);
            client = new MongoClient(_databaseconnection);
            server = client.GetServer();
            database = server.GetDatabase("meteor");
            game = database.GetCollection<GameEntity>("game");
            gamedata = database.GetCollection<GameCollection>("game");

            BsonClassMap.RegisterClassMap<GameEntity>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(c => c.user);
                cm.MapMember(c => c.health);
                cm.SetIgnoreExtraElements(true);
            });
            BsonClassMap.RegisterClassMap<GameCollection>(cm =>
            {
                cm.SetIdMember(cm.GetMemberMap(c => c._id));
                cm.MapMember(c => c.user);
                cm.MapMember(c => c.health);
                cm.SetIgnoreExtraElements(true);
            });
        }
        public void InsertGameEntity(GameEntity e)
        {
            //GameCollection gc = e;
            game.Insert(e);
            Debug.Log("InsertGameEntity-> ID:" + e._id);            
        }

        public void SaveGameEntity(GameEntity e)
        {           
            //GameCollection gc = e;
            game.Save(e);
            Debug.Log("SaveGameEntity-> ID:" + e._id);
        }
    }
}
