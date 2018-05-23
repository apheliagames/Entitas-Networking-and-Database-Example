using BeardedManStudios.Forge.Networking.Generated;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestClient : MonoBehaviour {

    MNB mnb;
    int health;
    
	// Use this for initialization
	void Start () {

        mnb = FindObjectOfType<MNB>();

        Debug.Log("Test Client");
        string userID = "QwkSmTCZiw5KDx3L6";
        string userName = "Robert";
        mnb.networkObject.SendRpc(EntitasBehavior.RPC_ADD_ACTIVE_PLAYER, BeardedManStudios.Forge.Networking.Receivers.Server, userID, userName);
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
