using UnityEngine;

public class CheckPoint : MonoBehaviour
{ 
	TrackCheckPoints _trackCheckPoints;
	SpriteRenderer _spriteRenderer;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void SetTrackCheckPoints(TrackCheckPoints trackCheckPoints)
	{
		_trackCheckPoints = trackCheckPoints;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			_trackCheckPoints.CheckPointTriggered(this);
		}
	}

	public void Show()
	{
		_spriteRenderer.enabled = true;
	}

	public void Hide()
	{
		_spriteRenderer.enabled = false;
	}
}
