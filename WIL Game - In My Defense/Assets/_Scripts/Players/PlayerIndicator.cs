using System;
using TMPro;
using UnityEngine;

namespace WilGame._Scripts.Players
{
    public class PlayerIndicator : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerNameText;
        [SerializeField] private TextMeshProUGUI indicatorText;
        
        public void SetStatus(PlayerStatus playerStatus)
        {
            indicatorText.text = playerStatus.ToString();
        }
        
        public void SetName(string name)
        {
            playerNameText.text = name;
        }
        
        
    }
}