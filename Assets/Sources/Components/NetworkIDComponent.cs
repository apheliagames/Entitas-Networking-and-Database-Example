using Entitas;
using Entitas.CodeGeneration.Attributes;

public class NetworkIDComponent : IComponent
{
    [PrimaryEntityIndex]
    public uint networkID;    
}