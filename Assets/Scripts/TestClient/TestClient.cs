using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;


public class TestClient : MonoBehaviour
{
    int health;
    EntitasBehavior entitasBehaviour;
    MNB mnb;
    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start()
    {
        mnb = FindObjectOfType<MNB>();
    }

    public void LoginPlayer()
    {
        Debug.Log("Test Client");
        string userID = "QwkSmTCZiw5KDx3L6";
        string userName = "Robert";
        mnb.networkObject.SendRpc(EntitasBehavior.RPC_ADD_ACTIVE_PLAYER, Receivers.Server, userID, userName);
    }

    public void SetHealthValue(string value)
    {
        health = Int32.Parse(value);
    }
    public void SendHealth()
    {
        mnb.networkObject.SendRpc(EntitasBehavior.RPC_CHANGE_HEALTH, BeardedManStudios.Forge.Networking.Receivers.Server, health);
    }
}
