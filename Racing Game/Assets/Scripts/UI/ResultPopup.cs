using System;
using TMPro;
using UnityEngine;

public class ResultPopup : MonoBehaviour
{
	[SerializeField] TMP_Text _trackName;
	[SerializeField] TMP_Text _result;
	[SerializeField] TMP_Text _bestResult;
	[SerializeField] GameObject _newBest;

	private void Start()
	{
		_newBest.SetActive(false);
	}

	public void SetResultData(string trackName, TimeSpan result, TimeSpan bestResult)
	{
		_trackName.text = trackName;
		_result.text = string.Format("{0:D2}:{1:D2}", result.Minutes, result.Seconds);
		_bestResult.text = string.Format("{0:D2}:{1:D2}", bestResult.Minutes, bestResult.Seconds);

		if (result > bestResult)
		{
			_newBest.SetActive(true);
		}
	}

	public void OnMenuClicked()
	{
		Game.Instance.ShowMainMenu();
		Destroy(gameObject);
	}
}
