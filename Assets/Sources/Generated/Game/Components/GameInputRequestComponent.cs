//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public InputRequestComponent inputRequest { get { return (InputRequestComponent)GetComponent(GameComponentsLookup.InputRequest); } }
    public bool hasInputRequest { get { return HasComponent(GameComponentsLookup.InputRequest); } }

    public void AddInputRequest(byte newRpcByteID, BeardedManStudios.Forge.Networking.RpcArgs newArgs) {
        var index = GameComponentsLookup.InputRequest;
        var component = CreateComponent<InputRequestComponent>(index);
        component.rpcByteID = newRpcByteID;
        component.args = newArgs;
        AddComponent(index, component);
    }

    public void ReplaceInputRequest(byte newRpcByteID, BeardedManStudios.Forge.Networking.RpcArgs newArgs) {
        var index = GameComponentsLookup.InputRequest;
        var component = CreateComponent<InputRequestComponent>(index);
        component.rpcByteID = newRpcByteID;
        component.args = newArgs;
        ReplaceComponent(index, component);
    }

    public void RemoveInputRequest() {
        RemoveComponent(GameComponentsLookup.InputRequest);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInputRequest;

    public static Entitas.IMatcher<GameEntity> InputRequest {
        get {
            if (_matcherInputRequest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InputRequest);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInputRequest = matcher;
            }

            return _matcherInputRequest;
        }
    }
}
