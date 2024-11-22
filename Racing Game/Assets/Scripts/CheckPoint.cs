using UnityEngine;
using Zenject;

public class CheckPoint : MonoBehaviour
{
	[SerializeField] bool isFinish;

	TrackCheckPoints _trackCheckPoints;
	SpriteRenderer _spriteRenderer;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	[Inject]
	private void Construct(TrackCheckPoints trackCheckPoints)
	{
		_trackCheckPoints = trackCheckPoints;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (isFinish)
		{
			_trackCheckPoints.FinishTriggered();
		}
		else
		{
			if (collision.gameObject.tag == "Player")
			{
				_trackCheckPoints.CheckPointTriggered(this);
			}
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
