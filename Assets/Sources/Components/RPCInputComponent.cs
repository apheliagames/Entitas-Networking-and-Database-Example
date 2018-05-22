using BeardedManStudios.Forge.Networking;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
public class RPCInputComponent : IComponent {

    public string context;
    public uint networkID;
    public byte rpcByteID;
    public RpcArgs args;
}
