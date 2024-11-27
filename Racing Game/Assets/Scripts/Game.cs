using Cinemachine;
using System;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
	[SerializeField] GameObject _resultPopupPrefab;
	[SerializeField] Car[] _cars;
	
	[Inject] Timer _timer;
	[Inject] DiContainer _diContainer;
	[Inject] CinemachineVirtualCamera _camera;
	[Inject] RecordManager _recordManager;

	public event Action OnQuitRace;

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

		Time.timeScale = 1;
		_timer.StartTimer();
	}

	public void GameOver() 
	{
		TimeSpan newResult = _timer.StopTimer();
		
		string carType = _car.GetCarType().ToString();
		TimeSpan bestResult = _recordManager.GetBestResult(carType);

		GameObject resultPopup = _diContainer.InstantiatePrefab(_resultPopupPrefab, _canvas.transform);
		resultPopup.GetComponent<ResultPopup>().SetResultData(newResult, bestResult);

		_recordManager.UpdateBestTime(carType, newResult);

		QuitRace();
	}

	public void QuitRace()
	{
		Destroy(_car.gameObject);
		Time.timeScale = 0;
		OnQuitRace();
	}
}
