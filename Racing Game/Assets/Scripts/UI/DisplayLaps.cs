using TMPro;
using UnityEngine;
using Zenject;

public class DisplayLaps : MonoBehaviour
{
	[SerializeField] TMP_Text _lapsText;

	[Inject] TrackCheckPoints _trackCheckPoints;

	int _lapsToWin;

	private void Awake()
	{
		_trackCheckPoints.OnLapUpdate += UpdateLapCount;
	}

	private void Start()
	{
		_lapsToWin = _trackCheckPoints.LapsToWin;
	}

	private void UpdateLapCount(int laps)
	{
		_lapsText.text = $"{laps}/{_lapsToWin}";
	}

	private void OnDestroy()
	{
		_trackCheckPoints.OnLapUpdate -= UpdateLapCount;
	}
}
