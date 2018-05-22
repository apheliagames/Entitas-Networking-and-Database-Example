using System.Collections.Generic;
using BeardedManStudios.Forge.Networking.Generated;
using Entitas;

public sealed class AddMoreHealthSystem : ReactiveSystem<GameEntity> {
        
	public AddMoreHealthSystem(Contexts contexts) : base(contexts.game)
    {
        
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.InputRequest);
    }
    protected override bool Filter(GameEntity entity)
    {
        UnityEngine.Debug.Log("AddMoreHealthSystem: " + entity.hasHealth + entity.hasInputRequest);
        return entity.hasInputRequest && entity.inputRequest.rpcByteID == EntitasBehavior.RPC_CHANGE_HEALTH;
    }
    
    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            e.health.value += e.inputRequest.args.GetNext<int>();
            e.isUpdateDatabase = true;
            if (e.health.value <= 0)
            e.isDestroyed = true;
            e.RemoveInputRequest();
        }
    }
}
