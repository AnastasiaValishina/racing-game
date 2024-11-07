using System;
using UnityEngine;

public class TrackCheckPoints : MonoBehaviour
{
	[SerializeField] CheckPoint[] checkPoints;
	[SerializeField] Finish _finish;

	int _lap = 0;

	public event EventHandler OnCorrectCheckPoint;
	public event EventHandler OnWrongCheckPoint;

	int _nextCheckPointIndex;

	private void Awake()
	{
		_nextCheckPointIndex = 0;

		foreach (var checkPoint in checkPoints)
        {
			checkPoint.SetTrackCheckPoints(this);
		}
    }

	private void Start()
	{
		checkPoints[0].Show();
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
				Debug.Log(_lap);
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
}
