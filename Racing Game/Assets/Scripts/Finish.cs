using UnityEngine;

public class Finish : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//_trackCheckPoints.CheckPointTriggered(this);
		}
	}
}
