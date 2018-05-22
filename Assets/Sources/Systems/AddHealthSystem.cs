using System.Collections.Generic;
using BeardedManStudios.Forge.Networking.Generated;
using Entitas;

public sealed class AddHealthSystem : ReactiveSystem<GameEntity> {
        
	public AddHealthSystem(Contexts contexts) : base(contexts.game)
    {
        
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.User);
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasUser && !entity.hasHealth;
    }
    
    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            e.AddHealth(200);
        }
    }
}
