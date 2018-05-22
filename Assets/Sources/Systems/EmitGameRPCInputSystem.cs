using System.Collections.Generic;
using BeardedManStudios.Forge.Networking.Generated;
using Entitas;

public sealed class EmitGameRPCInputSystem : ReactiveSystem<InputEntity>
{    
    GameContext gameContext;
    InputEntity[] _entities;
    Contexts contexts;


    public EmitGameRPCInputSystem(Contexts contexts) : base(contexts.input)
    {
        gameContext = contexts.game;
        this.contexts = contexts;
    }
    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.RPCInput);
    }    

    protected override bool Filter(InputEntity entity)
    {
        UnityEngine.Debug.Log("EmitGameRPCSystem: " + gameContext.contextInfo.name + entity.rPCInput.context);
        return entity.hasRPCInput && entity.rPCInput.context == gameContext.contextInfo.name;
    }
    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var ie in entities)
        {
            GameEntity ge = gameContext.GetEntityWithNetworkID(ie.rPCInput.networkID);
            
            if(!ge.hasInputRequest)//dont sent new input requests to entities who hasn't finished the last input request
                ge.AddInputRequest(ie.rPCInput.rpcByteID, ie.rPCInput.args);

            ie.Destroy();
        }
    }


}
