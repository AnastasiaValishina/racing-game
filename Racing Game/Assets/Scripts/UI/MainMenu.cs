using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenu : MonoBehaviour
{
	[SerializeField] ToggleGroup _toggleGroup;

	[Inject] Game _game;

	private Dictionary<Toggle, CarType> _toggleCarTypeMap;

	private void Awake()
	{
		_toggleCarTypeMap = new Dictionary<Toggle, CarType>();

		Toggle[] toggles = _toggleGroup.GetComponentsInChildren<Toggle>();

		if (toggles.Length >= System.Enum.GetValues(typeof(CarType)).Length)
		{
			_toggleCarTypeMap[toggles[0]] = CarType.Black;
			_toggleCarTypeMap[toggles[1]] = CarType.Blue;
			_toggleCarTypeMap[toggles[2]] = CarType.Green;
			_toggleCarTypeMap[toggles[3]] = CarType.Orange;
			_toggleCarTypeMap[toggles[4]] = CarType.Yellow;
		}
		else
		{
			Debug.LogError("Not enough toggles assigned in the ToggleGroup.");
		}
	}

	public void OnStartClicked()
	{
		CarType? selectedCarType = GetSelectedCarType();
		if (selectedCarType.HasValue)
		{
			_game.StartGame(selectedCarType);
		}
		else
		{
			Debug.Log("No CarType selected.");
		}

		gameObject.SetActive(false);
	}

	public void OnQuitClick()
	{
		Application.Quit();
	}

	private CarType? GetSelectedCarType()
	{
		Toggle selectedToggle = _toggleGroup.ActiveToggles().FirstOrDefault();

		if (selectedToggle != null && _toggleCarTypeMap.TryGetValue(selectedToggle, out CarType carType))
		{
			return carType;
		}
		return null; 
	}
}
