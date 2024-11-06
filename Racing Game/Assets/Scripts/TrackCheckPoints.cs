using System;
using UnityEngine;

public class TrackCheckPoints : MonoBehaviour
{
	[SerializeField] CheckPoint[] checkPoints;

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

			_nextCheckPointIndex = (_nextCheckPointIndex + 1) % checkPoints.Length;

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
