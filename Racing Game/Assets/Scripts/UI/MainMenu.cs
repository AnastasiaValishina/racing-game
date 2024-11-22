using UnityEngine;
using Zenject;

public class MainMenu : MonoBehaviour
{
	[Inject] Game _game;

	public void OnStartClicked()
	{
		_game.StartGame();
		gameObject.SetActive(false);
	}
}
