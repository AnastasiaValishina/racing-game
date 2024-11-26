using Cinemachine;
using System;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
	[SerializeField] ResultPopup _resultPopupPrefab;
	[SerializeField] Car[] _cars;
	
	[Inject] Timer _timer;
	[Inject] DiContainer _diContainer;
	[Inject] CinemachineVirtualCamera _camera;
	[Inject] RecordManager _recordManager;

	Canvas _canvas;
	Car _car;

	private void Awake()
	{
		_canvas = FindObjectOfType<Canvas>();
	}

	private void Start()
	{
		Time.timeScale = 0;
	}

	public void StartGame(CarType? selectedCarType)
	{
		_car = Instantiate(_cars[(int)selectedCarType]);
		_car.Init(_camera);
		Debug.Log(_car.GetCarType().ToString());

		Time.timeScale = 1;
		_timer.StartTimer();
	}

	public void GameOver() 
	{
		TimeSpan newResult = _timer.StopTimer();

		string carType = _car.GetCarType().ToString();
		_recordManager.UpdateBestTime(carType, newResult);

		ResultPopup resultPopup = Instantiate(_resultPopupPrefab, _canvas.transform);
		resultPopup.SetResultData(newResult, _recordManager.GetBestResult(carType));

		Time.timeScale = 0;
	}

	public void QuitRace()
	{
		Destroy(_car);
		Time.timeScale = 0;
	}
}
