using System;
using TMPro;
using UnityEngine;
using Zenject;

public class ResultPopup : MonoBehaviour
{
	[SerializeField] TMP_Text _result;
	[SerializeField] TMP_Text _bestResult;
	[SerializeField] GameObject _newBest;

	[Inject] Game _game;
	[Inject] MainMenu _mainMenu;

	public void SetResultData(TimeSpan result, TimeSpan bestResult)
	{
		_result.text = string.Format("{0:D2}:{1:D2}", result.Minutes, result.Seconds);
		_bestResult.text = string.Format("{0:D2}:{1:D2}", bestResult.Minutes, bestResult.Seconds);

		_newBest.SetActive(result < bestResult);
/*		if (result < bestResult)
		{
			_newBest.SetActive(true);
		}
		else 
		{
			_newBest.SetActive(false);
		}*/
	}

	public void OnMenuClicked()
	{
		_mainMenu.gameObject.SetActive(true);
		Destroy(gameObject);
	}
}
