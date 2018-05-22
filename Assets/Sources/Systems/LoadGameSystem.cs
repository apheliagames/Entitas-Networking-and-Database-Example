using Entitas;
using System;
using ApheliaGames.Backend;
using UnityEngine;

public sealed class LoadGameSystem : IInitializeSystem
{
    readonly Contexts _contexts;
    MongoDBController db;

    public LoadGameSystem(Contexts contexts)
    {
        _contexts = contexts;
        db = GameObject.FindObjectOfType<MongoDBController>();
    }

    public void Initialize()
    {
        Debug.Log("Initialize LoadGameSystem");
        GameCollection gc = db.gamedata.FindOne();
        Debug.Log("Initialize LoadGameSystem" + gc.health.value);
        var e = _contexts.game.CreateEntity();
        e._id = gc._id;
        e._guid = gc._guid;
        e.isDatabase = true;
        e.AddUser(gc.user.userID, gc.user.userName);
        e.AddHealth(gc.health.value);
              
    }
}