using System;
using Unity.Netcode;
using UnityEngine;

namespace WilGame._Scripts.Players
{
    public class PlayerManager : NetworkBehaviour
    {
        public static PlayerManager Instance;
        public NetworkVariable<Players> NetworkPlayers { get; private set; } = new();

        private void OnEnable()
        {
            //EventManager.onPlayerAnswerSubmitted.Subscribe();
        }

        private void OnDisable()
        {
            
        }

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();

            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }

            if (IsClient)
            {
                AddPlayerIdServerRpc(NetworkManager.Singleton.LocalClientId);
                Debug.Log("Added player id: " + NetworkManager.Singleton.LocalClientId);
            }
        }

        [ServerRpc(RequireOwnership = false)]
        private void AddPlayerIdServerRpc(ulong playerId)
        {
            NetworkPlayers.Value.PlayersList.Add(new Player(playerId));
        }
        
        [ServerRpc(RequireOwnership = false)]
        public void GetPlayersServerRpc(out Players players)
        {
            players = NetworkPlayers.Value;
        }
    }
}