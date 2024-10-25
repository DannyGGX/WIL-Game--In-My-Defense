using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;


namespace WilGame._Scripts.Answers
{
	
	public class AnswerInputUI : NetworkBehaviour
	{
		[SerializeField] private TMP_InputField answerInput;
		[SerializeField] private Button submitButton;
        

		private void Awake()
		{
			submitButton.onClick.AddListener(SubmitAnswer);
		}

		private void SubmitAnswer()
		{
			AnswerManager.Instance.AddAnswerServerRpc(answerInput.text, AnswerManager.Instance.OwnerClientId);
			Debug.Log("SubmitAnswer called");
			
			EventManager.onPlayerAnswerSubmitted.Invoke(AnswerManager.Instance.OwnerClientId);
		}
	}
}
