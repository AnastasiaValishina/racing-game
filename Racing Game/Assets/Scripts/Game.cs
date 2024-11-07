using System;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] Timer _timer;
	[SerializeField] ResultPopup _resultPopupPrefab;
	[SerializeField] MainMenu _mainMenu;

	RecordManager _recordManager;
	Canvas _canvas;
	
	public event Action GameStarted;
	public event Action GameEnded;

	static Game instance;
	public static Game Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<Game>();
			}
			return instance;
		}
	}

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
