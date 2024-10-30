using System;
using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
	[SerializeField] TMP_Text _timerText;

	float _time;
	bool _isRunning = false;
	TimeSpan _timeSpan;

	private void Update()
	{
		if (_isRunning)
		{
			_time += Time.deltaTime;

			_timeSpan = TimeSpan.FromSeconds(_time);

			_timerText.text = string.Format("{0:D2}:{1:D2}", _timeSpan.Minutes, _timeSpan.Seconds);
		}
	}
	public void StartTimer()
	{
		_time = 0;
		_isRunning = true;
	}

	public TimeSpan StopTimer()
	{
		_isRunning = false;
		return _timeSpan;
	}
}
