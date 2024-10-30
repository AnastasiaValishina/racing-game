using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public void OnTrackSelected(int index)
	{
		Game.Instance.StartGame(index);
		gameObject.SetActive(false);
	}
}
