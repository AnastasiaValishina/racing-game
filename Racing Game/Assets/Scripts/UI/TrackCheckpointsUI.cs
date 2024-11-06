using UnityEngine;

public class TrackCheckpointsUI : MonoBehaviour
{
	[SerializeField] TrackCheckPoints _trackCheckPoints;

	private void Start()
	{
		_trackCheckPoints.OnCorrectCheckPoint += TrackCheckPoints_OnCorrectCheckPoint;
		_trackCheckPoints.OnWrongCheckPoint += TrackCheckPoints_OnWrongCheckPoint;
		Hide();
	}

	private void TrackCheckPoints_OnCorrectCheckPoint(object sender, System.EventArgs e)
	{
		Hide();
	}
	private void TrackCheckPoints_OnWrongCheckPoint(object sender, System.EventArgs e)
	{
		Show();
	}

	void Show()
	{
		gameObject.SetActive(true);
	}

	void Hide()
	{
		gameObject.SetActive(false);
	}
}
