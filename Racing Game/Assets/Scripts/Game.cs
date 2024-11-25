using System;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
	[SerializeField] ResultPopup _resultPopupPrefab;
	[SerializeField] Car[] _cars;
	
	[Inject] MainMenu _mainMenu; // to remove
	[Inject] Timer _timer;
	[Inject] DiContainer _diContainer;

	RecordManager _recordManager;
	Canvas _canvas;
	Car _car;

	private void Awake()
	{
		_recordManager = GetComponent<RecordManager>();
		_canvas = FindObjectOfType<Canvas>();
	}

	private void Start()
	{
		Time.timeScale = 0;
		_mainMenu.gameObject.SetActive(true);
	}

	public void StartGame(CarType? selectedCarType)
	{
		_car = Instantiate(_cars[(int)selectedCarType]);
		_car.Init();
		Time.timeScale = 1;
		_timer.StartTimer();
	}

	public void GameOver() 
	{
		TimeSpan newResult = _timer.StopTimer();

		ResultPopup resultPopup = Instantiate(_resultPopupPrefab, _canvas.transform);
		resultPopup.SetResultData(newResult, new TimeSpan(0, 3, 0));

		Time.timeScale = 0;
	}

	public void QuitRace()
	{
		ShowMainMenu();
		Time.timeScale = 0;
	}

	public void ShowMainMenu()
	{
		_mainMenu.gameObject.SetActive(true);
	}
}
