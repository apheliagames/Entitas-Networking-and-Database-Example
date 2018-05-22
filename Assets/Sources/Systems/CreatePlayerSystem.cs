using Entitas;
using System;
using MongoDB.Bson;

public sealed class CreatePlayerSystem : IInitializeSystem
{
    readonly Contexts _contexts; 

    public CreatePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var e = _contexts.game.CreateEntity();
        
        e.AddPosition(2, 4);
        
    }
}