using JetBrains.Annotations;
using Unity.Netcode;

namespace WilGame._Scripts.Players
{
    public struct Player : INetworkSerializable
    {
        public string Name;
        public ulong Id;
        public PlayerStatus CurrentStatus;
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref Name);
            serializer.SerializeValue(ref Id);
            serializer.SerializeValue(ref CurrentStatus);
        }
        
        public Player(string name, ulong id)
        {
            Name = name;
            Id = id;
            CurrentStatus = PlayerStatus.Pending;
        }

        public Player(ulong id)
        {
            Name = "Player " + id;
            Id = id;
            CurrentStatus = PlayerStatus.Pending;
        }
    }
}