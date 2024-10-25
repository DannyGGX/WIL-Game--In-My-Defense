using System.Collections.Generic;
using Unity.Netcode;

namespace WilGame._Scripts.Answers
{
    public struct Answers : INetworkSerializeByMemcpy // INetworkSerializable is not able to serialize lists
    {
        public List<Answer> AnswersList { get; set; }
    }
}