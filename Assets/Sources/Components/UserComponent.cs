using Entitas;
using Entitas.CodeGeneration.Attributes;

public class UserComponent : IComponent
{
    [EntityIndex]
    public string userID;
    public string userName;
}