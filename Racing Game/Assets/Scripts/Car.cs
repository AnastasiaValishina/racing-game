using System;
using UnityEngine;
using Zenject;

public class Car : MonoBehaviour
{
    [SerializeField] float accelerationFactor = 30.0f;
    [SerializeField] float turnFactor = 3.5f;
	[SerializeField] float driftFactor = 0.9f;

    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    Rigidbody2D _rb;

	Game _game;

	[Inject]
	private void Consruct(Game game)
	{
		_game = game;
		Debug.Log("Game injected");
	}

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	public void Init()
	{
		SetStartPosition();
	}

	void Update()
    {	
		steeringInput = Input.GetAxis("Horizontal");
		accelerationInput = Input.GetAxis("Vertical");
	}

	private void FixedUpdate()
	{
        ApplyEngineForce();
		KillOrthogonalVelocity();

		ApplySteering();
	}

	private void SetStartPosition()
	{
		rotationAngle = 0;
		_rb.velocity = Vector3.zero;
		_rb.angularVelocity = 0;

		transform.position = new Vector2(-7.6f, - 2.15f);
		transform.eulerAngles = Vector3.zero;
	}

	private void ApplySteering()
	{
		float minSpeedBeforeAllowTurningfactor = _rb.velocity.magnitude / 8;

		minSpeedBeforeAllowTurningfactor = Mathf.Clamp01(minSpeedBeforeAllowTurningfactor);

		rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningfactor;
		_rb.MoveRotation(rotationAngle);
	}

	private void ApplyEngineForce()
	{
		Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;
		_rb.AddForce(engineForceVector, ForceMode2D.Force);
	}

	void KillOrthogonalVelocity()
	{
		Vector2 forwardVelocity = transform.up * Vector2.Dot(_rb.velocity, transform.up);
		Vector2 rightVelocity = transform.right * Vector2.Dot(_rb.velocity, transform.right);

		_rb.velocity = forwardVelocity + rightVelocity * driftFactor;
	}
}
