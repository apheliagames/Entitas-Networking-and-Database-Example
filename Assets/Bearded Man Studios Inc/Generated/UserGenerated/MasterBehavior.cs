using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedRPC("{\"types\":[[\"string\"][\"string\", \"bool\"][\"string\"][\"string\"][\"string\"][][\"int\"][][][][][][][\"string\", \"bool\", \"string\"][\"string\", \"bool\"][\"int\", \"bool\"][\"string\", \"string\"][\"string\", \"string\"][\"byte\", \"byte\", \"byte\", \"bool\"][\"int\", \"string\"]]")]
	[GeneratedRPCVariableNames("{\"types\":[[\"message\"][\"userInitData\", \"isNewUser\"][\"userID\"][\"userID\"][\"targetSystemID\"][][\"clickedOrbit\"][][][][][][][\"fromRPC\", \"result\", \"returnString\"][\"trigger\", \"value\"][\"galaxyObjectNumber\", \"realtime\"][\"bmcRequest\", \"arguments\"][\"bmcRequest\", \"arguments\"][\"shipID\", \"orbitNumber\", \"resourceType\", \"cancel\"][\"logBookOrder\", \"parameter\"]]")]
	public abstract partial class MasterBehavior : NetworkBehavior
	{
		public const byte RPC_SEND_MESSAGE = 0 + 5;
		public const byte RPC_ADD_ACTIVE_PLAYER = 1 + 5;
		public const byte RPC_REMOVE_ACTIVE_PLAYER = 2 + 5;
		public const byte RPC_CLIENT_LOAD_MOTHERSHIP = 3 + 5;
		public const byte RPC_START_TRAVEL = 4 + 5;
		public const byte RPC_CHECK_TRAVEL = 5 + 5;
		public const byte RPC_ENTER_ORBIT = 6 + 5;
		public const byte RPC_LEAVE_ORBIT = 7 + 5;
		public const byte RPC_COLONIZE_PLANET = 8 + 5;
		public const byte RPC_CAN_COLONIZE = 9 + 5;
		public const byte RPC_LAND_ON_PLANET = 10 + 5;
		public const byte RPC_CAN_LAND_ON_PLANET = 11 + 5;
		public const byte RPC_CLIENT_ENTER_ORBIT = 12 + 5;
		public const byte RPC_SEND_CALLBACK_TO_CLIENT = 13 + 5;
		public const byte RPC_SEND_EVENT_TRIGGER = 14 + 5;
		public const byte RPC_CALCULATE_TRAVEL_TIME = 15 + 5;
		public const byte RPC_SEND_BMC_REQUEST = 16 + 5;
		public const byte RPC_SEND_BMC_CALLBACK_TO_CLIENT = 17 + 5;
		public const byte RPC_START_MINING_MISSION = 18 + 5;
		public const byte RPC_LOG_BOOK = 19 + 5;
		
		public MasterNetworkObject networkObject = null;

		public override void Initialize(NetworkObject obj)
		{
			// We have already initialized this object
			if (networkObject != null && networkObject.AttachedBehavior != null)
				return;
			
			networkObject = (MasterNetworkObject)obj;
			networkObject.AttachedBehavior = this;

			base.SetupHelperRpcs(networkObject);
			networkObject.RegisterRpc("SendMessage", SendMessage, typeof(string));
			networkObject.RegisterRpc("AddActivePlayer", AddActivePlayer, typeof(string), typeof(bool));
			networkObject.RegisterRpc("RemoveActivePlayer", RemoveActivePlayer, typeof(string));
			networkObject.RegisterRpc("ClientLoadMothership", ClientLoadMothership, typeof(string));
			networkObject.RegisterRpc("StartTravel", StartTravel, typeof(string));
			networkObject.RegisterRpc("CheckTravel", CheckTravel);
			networkObject.RegisterRpc("EnterOrbit", EnterOrbit, typeof(int));
			networkObject.RegisterRpc("LeaveOrbit", LeaveOrbit);
			networkObject.RegisterRpc("ColonizePlanet", ColonizePlanet);
			networkObject.RegisterRpc("CanColonize", CanColonize);
			networkObject.RegisterRpc("LandOnPlanet", LandOnPlanet);
			networkObject.RegisterRpc("CanLandOnPlanet", CanLandOnPlanet);
			networkObject.RegisterRpc("ClientEnterOrbit", ClientEnterOrbit);
			networkObject.RegisterRpc("SendCallbackToClient", SendCallbackToClient, typeof(string), typeof(bool), typeof(string));
			networkObject.RegisterRpc("SendEventTrigger", SendEventTrigger, typeof(string), typeof(bool));
			networkObject.RegisterRpc("CalculateTravelTime", CalculateTravelTime, typeof(int), typeof(bool));
			networkObject.RegisterRpc("SendBmcRequest", SendBmcRequest, typeof(string), typeof(string));
			networkObject.RegisterRpc("SendBmcCallbackToClient", SendBmcCallbackToClient, typeof(string), typeof(string));
			networkObject.RegisterRpc("StartMiningMission", StartMiningMission, typeof(byte), typeof(byte), typeof(byte), typeof(bool));
			networkObject.RegisterRpc("LogBook", LogBook, typeof(int), typeof(string));

			networkObject.onDestroy += DestroyGameObject;

			if (!obj.IsOwner)
			{
				if (!skipAttachIds.ContainsKey(obj.NetworkId))
					ProcessOthers(gameObject.transform, obj.NetworkId + 1);
				else
					skipAttachIds.Remove(obj.NetworkId);
			}

			if (obj.Metadata != null)
			{
				byte transformFlags = obj.Metadata[0];

				if (transformFlags != 0)
				{
					BMSByte metadataTransform = new BMSByte();
					metadataTransform.Clone(obj.Metadata);
					metadataTransform.MoveStartIndex(1);

					if ((transformFlags & 0x01) != 0 && (transformFlags & 0x02) != 0)
					{
						MainThreadManager.Run(() =>
						{
							transform.position = ObjectMapper.Instance.Map<Vector3>(metadataTransform);
							transform.rotation = ObjectMapper.Instance.Map<Quaternion>(metadataTransform);
						});
					}
					else if ((transformFlags & 0x01) != 0)
					{
						MainThreadManager.Run(() => { transform.position = ObjectMapper.Instance.Map<Vector3>(metadataTransform); });
					}
					else if ((transformFlags & 0x02) != 0)
					{
						MainThreadManager.Run(() => { transform.rotation = ObjectMapper.Instance.Map<Quaternion>(metadataTransform); });
					}
				}
			}

			MainThreadManager.Run(() =>
			{
				NetworkStart();
				networkObject.Networker.FlushCreateActions(networkObject);
			});
		}

		protected override void CompleteRegistration()
		{
			base.CompleteRegistration();
			networkObject.ReleaseCreateBuffer();
		}

		public override void Initialize(NetWorker networker, byte[] metadata = null)
		{
			Initialize(new MasterNetworkObject(networker, createCode: TempAttachCode, metadata: metadata));
		}

		private void DestroyGameObject(NetWorker sender)
		{
			MainThreadManager.Run(() => { try { Destroy(gameObject); } catch { } });
			networkObject.onDestroy -= DestroyGameObject;
		}

		public override NetworkObject CreateNetworkObject(NetWorker networker, int createCode, byte[] metadata = null)
		{
			return new MasterNetworkObject(networker, this, createCode, metadata);
		}

		protected override void InitializedTransform()
		{
			networkObject.SnapInterpolations();
		}

		/// <summary>
		/// Arguments:
		/// string message
		/// </summary>
		public abstract void SendMessage(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// string userInitData
		/// bool isNewUser
		/// </summary>
		public abstract void AddActivePlayer(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// string userID
		/// </summary>
		public abstract void RemoveActivePlayer(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// string userID
		/// </summary>
		public abstract void ClientLoadMothership(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// string targetSystemID
		/// </summary>
		public abstract void StartTravel(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void CheckTravel(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void EnterOrbit(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void LeaveOrbit(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void ColonizePlanet(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void CanColonize(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void LandOnPlanet(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void CanLandOnPlanet(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void ClientEnterOrbit(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void SendCallbackToClient(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void SendEventTrigger(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void CalculateTravelTime(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void SendBmcRequest(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void SendBmcCallbackToClient(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void StartMiningMission(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// </summary>
		public abstract void LogBook(RpcArgs args);

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}