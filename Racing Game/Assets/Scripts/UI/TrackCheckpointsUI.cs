using UnityEngine;
using Zenject;

public class TrackCheckpointsUI : MonoBehaviour
{
	[Inject] TrackCheckPoints _trackCheckPoints;
	[Inject] Game _game;

	private void Start()
	{
		_trackCheckPoints.OnCorrectCheckPoint += TrackCheckPoints_OnCorrectCheckPoint;
		_trackCheckPoints.OnWrongCheckPoint += TrackCheckPoints_OnWrongCheckPoint;
		_game.OnQuitRace += Game_OnQuitRace;
		Hide();
	}

	private void Game_OnQuitRace()
	{
		Hide();
	}

	private void TrackCheckPoints_OnCorrectCheckPoint(object sender, System.EventArgs e)
	{
		Hide();
	}
	private void TrackCheckPoints_OnWrongCheckPoint(object sender, System.EventArgs e)
	{
		Show();
	}

	void Show()
	{
		gameObject.SetActive(true);
	}

	void Hide()
	{
		gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		_trackCheckPoints.OnCorrectCheckPoint -= TrackCheckPoints_OnCorrectCheckPoint;
		_trackCheckPoints.OnWrongCheckPoint -= TrackCheckPoints_OnWrongCheckPoint;
		_game.OnQuitRace -= Game_OnQuitRace;
	}
}
