using System.Collections.Generic;
using Unity.Netcode;

namespace WilGame._Scripts.Players
{
    public struct Players : INetworkSerializeByMemcpy // INetworkSerializable is not able to serialize lists
    {
        public List<Player> PlayersList { get; set; }

        public Player GetPlayer(ulong id)
        {
            return PlayersList.Find(x => x.Id == id);
        }
    }
}