using Entitas;

public sealed class DestroySystem : IExecuteSystem
{

    readonly IGroup<GameEntity> _gameentities;    

    public DestroySystem(Contexts contexts)
    {
        _gameentities = contexts.game.GetGroup(GameMatcher.Destroyed);        
    }
    public void Execute()
    {
        foreach (var e in _gameentities.GetEntities())
        {
            e.Destroy();
        }        
    }
}