using UnityEngine;
using Zenject;

public class QuitButton : MonoBehaviour
{
	Game _game;

	[Inject]
	private void Consruct(Game game)
	{
		_game = game;
	}

	public void OnQuitClick()
	{
		_game.QuitRace();
	}
}
