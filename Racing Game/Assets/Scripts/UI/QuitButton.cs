using UnityEngine;

public class QuitButton : MonoBehaviour
{
	public void OnQuitClick()
	{
		Game.Instance.QuitRace();
	}
}
