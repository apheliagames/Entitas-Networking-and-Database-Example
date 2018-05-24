using Entitas;

public sealed class InputFeature : Feature
{
    public InputFeature(Contexts contexts)
    {        
        Add(new EmitGameRPCInputSystem(contexts));
        Add(new DestroyInputSystem(contexts));
    }
}