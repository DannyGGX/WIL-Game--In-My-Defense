using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace WilGame._Scripts.Players
{
    public class PlayerIndicatorGroup : NetworkBehaviour
    {
        [SerializeField] private HorizontalLayoutGroup layoutGroup;
        [SerializeField] private PlayerIndicator playerIndicatorPrefab;
        
        private List<PlayerIndicator> playerIndicators;

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
            PlayerManager.Instance.GetPlayersServerRpc(out Players players);
            playerIndicators = new List<PlayerIndicator>(players.PlayersList.Count);
            foreach (Player player in players.PlayersList)
            {
                AddPlayerIndicator(player);
            }
        }
        
        private void AddPlayerIndicator(Player player)
        {
            PlayerIndicator indicator = Instantiate(playerIndicatorPrefab, layoutGroup.transform);
            indicator.SetName(player.Name);
            indicator.SetStatus(player.CurrentStatus);
            playerIndicators.Add(indicator);
        }
        
        
        
    }
}