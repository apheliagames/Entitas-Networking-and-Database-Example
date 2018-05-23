using Entitas;

public sealed class PersistingNetworkGameFeature : Feature
{
    public PersistingNetworkGameFeature(Contexts contexts)
    {
        //Init
        //Add(new CreatePlayerSystem(contexts));
        Add(new LoadGameSystem(contexts));
        //Input
        //Update
        Add(new AddActivePlayerSystem(contexts));
        Add(new AddHealthSystem(contexts));
        Add(new LogHealthSystem(contexts));
        Add(new AddMoreHealthSystem(contexts));
        Add(new UpdateDatabaseSystem(contexts));
        //Views

        //CleanUp
        Add(new DestroySystem(contexts));
    }
}