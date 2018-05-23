using Entitas;

public sealed class NetworkOnlyGameFeature : Feature
{
    public NetworkOnlyGameFeature(Contexts contexts)
    {        
        Add(new AddActivePlayerSystem(contexts));
        Add(new AddHealthSystem(contexts));
        Add(new LogHealthSystem(contexts));
        Add(new AddMoreHealthSystem(contexts));
        
        //CleanUp
        Add(new DestroySystem(contexts));
    }
}