using UnityEngine;
using Zenject;

public class CheckPoint : MonoBehaviour
{
	[SerializeField] bool isFinish;

	Game _game;

	TrackCheckPoints _trackCheckPoints;
	SpriteRenderer _spriteRenderer;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_game.OnQuitRace += OnQuitRace;
	}

	private void OnQuitRace()
	{
		Hide();
	}

	[Inject]
	private void Construct(TrackCheckPoints trackCheckPoints, Game game)
	{
		_trackCheckPoints = trackCheckPoints;
		_game = game;
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
	private void OnDestroy()
	{
		_game.OnQuitRace -= OnQuitRace;
	}
}
