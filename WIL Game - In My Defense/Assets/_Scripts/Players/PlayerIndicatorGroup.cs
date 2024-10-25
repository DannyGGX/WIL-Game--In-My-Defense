using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace WilGame._Scripts.Players
{
    public class PlayerIndicatorGroup : NetworkBehaviour
    {
        [SerializeField] private HorizontalLayoutGroup layoutGroup;
        [SerializeField] private PlayerIndicator playerIndicatorPrefab;
        
        private PlayerIndicator[] playerIndicators;

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
            
        }
        
        private void AddPlayerIndicator(Player player)
        {
            PlayerIndicator indicator = Instantiate(playerIndicatorPrefab, layoutGroup.transform);
            indicator.SetName(player.Name);
            indicator.SetStatus(player.CurrentStatus);
            playerIndicators = layoutGroup.GetComponentsInChildren<PlayerIndicator>();
        }
        
        
        
    }
}