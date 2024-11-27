using System;
using UnityEngine;
using Zenject;

public class TrackCheckPoints : MonoBehaviour
{
	[SerializeField] CheckPoint[] checkPoints;
	[SerializeField] CheckPoint _finish;

	[Inject] Game _game;

	int _lap = 0;
	private const int _lapsToWin = 3;
	public int LapsToWin => _lapsToWin;

	public event EventHandler OnCorrectCheckPoint;
	public event EventHandler OnWrongCheckPoint;

	public event Action<int> OnLapUpdate;

	int _nextCheckPointIndex;

	private void Awake()
	{
		_nextCheckPointIndex = 0;
		_game.OnQuitRace += OnQuitRace;
	}

	private void Start()
	{
		checkPoints[0].Show();
		OnLapUpdate(_lap);
	}

	public void CheckPointTriggered(CheckPoint checkPoint)
	{
		int index = Array.FindIndex(checkPoints, cp => cp == checkPoint);
		if (index == _nextCheckPointIndex) 
		{
			checkPoints[_nextCheckPointIndex].Hide();

			_nextCheckPointIndex++;

			if (_nextCheckPointIndex > checkPoints.Length - 1)
			{
				_nextCheckPointIndex = 0;
				_lap++;
				OnLapUpdate(_lap);

				if (_lap >= _lapsToWin) _finish.Show();
			}

			checkPoints[_nextCheckPointIndex].Show();
			OnCorrectCheckPoint?.Invoke(this, EventArgs.Empty);
		}
		else
		{
			OnWrongCheckPoint?.Invoke(this, EventArgs.Empty);

			var correctCheckPoint = checkPoints[_nextCheckPointIndex];
		}
	}

	public void FinishTriggered()
	{
		if (_lap >= _lapsToWin)
		{
			_game.GameOver();
		}
	}

	public void OnQuitRace()
	{
		_nextCheckPointIndex = 0;
		_lap = 0;
		OnLapUpdate(_lap);
	}

	private void OnDestroy()
	{
		_game.OnQuitRace -= OnQuitRace;
	}
}
