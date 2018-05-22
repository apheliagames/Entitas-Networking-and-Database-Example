using BeardedManStudios.Forge.Networking;
using Entitas;


[Game]
public class InputRequestComponent : IComponent {

    public byte rpcByteID;
    public RpcArgs args;
}
