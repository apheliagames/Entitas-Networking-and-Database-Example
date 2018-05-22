using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using Entitas;
using ApheliaGames.Backend;

public class MNB : EntitasBehavior {

    Contexts contexts;
    
    InputFeature _inputsystems;
    TestClient testClient;
    GameController gameController;

    protected override void NetworkStart()
    {
        base.NetworkStart();       
        
        if (networkObject.IsServer)
        {
            Debug.Log("Network Server started");
            networkObject.Networker.playerAccepted += PlayerAcceptedSetup;
            networkObject.Networker.playerDisconnected += PlayerDisconnectedHandler;
            contexts = Contexts.sharedInstance;
            _inputsystems = new InputFeature(contexts);            
            _inputsystems.Initialize();
            gameController = FindObjectOfType<GameController>();
            gameController.enabled = true;
        }
        else
        {
            Debug.Log("Network Client started");
            testClient = FindObjectOfType<TestClient>();
            testClient.enabled = true;
        }
    }
        
    private void PlayerDisconnectedHandler(NetworkingPlayer player, NetWorker sender)
    {
        MainThreadManager.Run(() => DisconnectPlayer(player));
    }

    private void DisconnectPlayer(NetworkingPlayer player)
    {
        var e = contexts.game.GetEntityWithNetworkID(player.NetworkId);
        e.Destroy();
    }

    private void PlayerAcceptedSetup(NetworkingPlayer player, NetWorker sender)
    {
        MainThreadManager.Run(() => ConnectNewPlayer(player));
        //e.AddNetworkID(player.NetworkId);
        //e.isClientConnected = true;
    }
    private void ConnectNewPlayer(NetworkingPlayer player)
    {
        var e = contexts.game.CreateEntity();
        e.AddNetworkID(player.NetworkId);
        e.isClientConnected = true;
    }

    public override void AddActivePlayer(RpcArgs args)
    {
        Debug.Log("Add Active Player RPC");
        var e = contexts.input.CreateEntity();
        e.AddRPCInput(contexts.game.contextInfo.name, args.Info.SendingPlayer.NetworkId, EntitasBehavior.RPC_ADD_ACTIVE_PLAYER, args);
        _inputsystems.Execute();
    }

    public override void ChangeHealth(RpcArgs args)
    {
        Debug.Log("Change Health RPC");
        var e = contexts.input.CreateEntity();
        e.AddRPCInput(contexts.game.contextInfo.name, args.Info.SendingPlayer.NetworkId, EntitasBehavior.RPC_CHANGE_HEALTH, args);
        _inputsystems.Execute();
    }
    
}
