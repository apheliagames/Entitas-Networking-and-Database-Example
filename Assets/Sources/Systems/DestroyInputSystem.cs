using Entitas;

public sealed class DestroyInputSystem : IExecuteSystem
{
    readonly IGroup<InputEntity> _inputentities;    

    public DestroyInputSystem(Contexts contexts)
    {
        _inputentities = contexts.input.GetGroup(InputMatcher.Destroyed);        
    }
    public void Execute()
    {
        foreach (var e in _inputentities.GetEntities())
        {
            e.Destroy();
        }        
    }
}