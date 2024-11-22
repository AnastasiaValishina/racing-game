using System;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
	[SerializeField] ResultPopup _resultPopupPrefab;
	
	[Inject] MainMenu _mainMenu;
	[Inject] Timer _timer;
	[Inject] DiContainer _diContainer;

	RecordManager _recordManager;
	Canvas _canvas;
	
	public event Action GameStarted;
	public event Action GameEnded;

	private void Awake()
	{
		_recordManager = GetComponent<RecordManager>();
		_canvas = FindObjectOfType<Canvas>();
	}

	private void Start()
	{
		_mainMenu.gameObject.SetActive(true);
	}

	public void StartGame()
	{
		GameStarted();
		_timer.StartTimer();
	}

	public void GameOver() 
	{
		TimeSpan newResult = _timer.StopTimer();

		ResultPopup resultPopup = Instantiate(_resultPopupPrefab, _canvas.transform);
		resultPopup.SetResultData(newResult, new TimeSpan(0, 3, 0));

		GameEnded();
	}

	public void QuitRace()
	{
		GameEnded();
		ShowMainMenu();
	}

	public void ShowMainMenu()
	{
		_mainMenu.gameObject.SetActive(true);
	}
}
