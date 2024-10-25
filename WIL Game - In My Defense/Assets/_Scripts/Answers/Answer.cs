using Unity.Collections;
using Unity.Netcode;

namespace WilGame._Scripts.Answers
{
    public struct Answer : INetworkSerializable
    {
        public string AnswerText;

        public ulong Id; // to determine whose answer it is
        
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref AnswerText);
            serializer.SerializeValue(ref Id);
        }

        public Answer(string answerText, ulong id)
        {
            AnswerText = answerText;
            Id = id;
        }
            
    }
}