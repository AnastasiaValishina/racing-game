using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public void OnStartClicked()
	{
		Game.Instance.StartGame();
		gameObject.SetActive(false);
	}
}
