using System;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
	BoxCollider2D _collider2d;

	public event Action Exit;

	public bool IsLast { get; set; } = false;

	private void Awake()
	{
		var rb = gameObject.AddComponent<Rigidbody2D>();
		rb.bodyType = RigidbodyType2D.Static;
		_collider2d = gameObject.AddComponent<BoxCollider2D>();
		_collider2d.isTrigger = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			if (IsLast)
			{
				Game.Instance.GameOver();
			}
			Exit();
		}
	}
}
