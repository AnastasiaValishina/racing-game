using UnityEngine;
using Zenject;

public class QuitButton : MonoBehaviour
{
	[Inject] Game _game;
	[Inject] MainMenu _mainMenu;

	public void OnQuitClick()
	{
		_mainMenu.gameObject.SetActive(true);
		_game.QuitRace();
	}
}
