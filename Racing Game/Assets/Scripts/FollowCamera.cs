using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	[SerializeField] Transform target;

	void LateUpdate()
	{
		transform.position = new Vector3(target.position.x, target.position.y + 3, -10);
	}
}
