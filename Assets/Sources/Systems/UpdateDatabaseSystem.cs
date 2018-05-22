using System.Collections.Generic;
using Entitas;
using UnityEngine;
using ApheliaGames.Backend;
using Newtonsoft.Json;

public sealed class UpdateDatabaseSystem : ReactiveSystem<GameEntity>
{
    MongoDBController db;

    public UpdateDatabaseSystem(Contexts contexts) : base(contexts.game)
    {
        db = GameObject.FindObjectOfType<MongoDBController>();
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.UpdateDatabase);
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.isUpdateDatabase;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // write an implicit operator to convert entity to collection and then save it
            e.isUpdateDatabase = false;

            if (e.isDatabase)
                db.SaveGameEntity(e);
            else
            {
                db.InsertGameEntity(e);                
                e.isDatabase = true;
            }
            Debug.Log("Save Game Data-> ID:" + e._id);
            
        }
    }
}

