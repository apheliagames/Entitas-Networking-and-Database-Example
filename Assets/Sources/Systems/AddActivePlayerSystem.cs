using System.Collections.Generic;
using BeardedManStudios.Forge.Networking.Generated;
using Entitas;

public sealed class AddActivePlayerSystem : ReactiveSystem<GameEntity>
{    
    public AddActivePlayerSystem(Contexts contexts) : base(contexts.game)
    {
        
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.InputRequest);
    }    

    protected override bool Filter(GameEntity entity)
    {
        UnityEngine.Debug.Log("AddActivePlayer Filter" + entity.hasInputRequest + entity.inputRequest.rpcByteID);
        return entity.hasInputRequest && entity.inputRequest.rpcByteID == EntitasBehavior.RPC_ADD_ACTIVE_PLAYER;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            UnityEngine.Debug.Log("AddActivePlayer.Execute -> e" + e.networkID);
            e.AddUser(e.inputRequest.args.GetNext<string>(), e.inputRequest.args.GetNext<string>());
            e.RemoveInputRequest();            
        }
    }    
}
