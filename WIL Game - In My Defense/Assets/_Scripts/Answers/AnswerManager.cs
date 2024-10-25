using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;


namespace WilGame._Scripts.Answers
{
	
	public class AnswerManager : NetworkBehaviour
	{
		public static AnswerManager Instance;
		
		public NetworkVariable<Answers> NetworkAnswers { get; private set; } = new ( new Answers
		{
			AnswersList = new List<Answer>()
		});
		
		public override void OnNetworkSpawn()
		{
			base.OnNetworkSpawn();
			if (Instance == null)
			{
				Instance = this;
				DontDestroyOnLoad(gameObject);
				Debug.Log("Singleton instance assigned");
			}
			else if (Instance != this)
			{
				Destroy(gameObject);
			}
		}


		[ServerRpc(RequireOwnership = false)]
		public void AddAnswerServerRpc(string answer, ulong playerId)
		{
			Answer answerStruct = new Answer(answer, playerId);
			NetworkAnswers.Value.AnswersList.Add(answerStruct);
		}

		[ServerRpc(RequireOwnership = false)]
		public void ClearAnswersServerRpc()
		{
			NetworkAnswers.Value.AnswersList.Clear();
		}
		
		
		
	}
}
