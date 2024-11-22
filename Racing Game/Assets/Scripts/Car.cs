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

    Rigidbody2D carRigidbody2D;

	[Inject]
	Game _game;

	private void Awake()
	{
		carRigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		_game.GameStarted += OnGameStarted;
		_game.GameEnded += OnGameEnded;
	}
	private void OnGameEnded()
	{
/*		SetStartPosition();
		canMove = false;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0;*/
	}

	private void OnGameStarted()
	{
/*		SetStartPosition();
		canMove = true;*/
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

	private void ApplySteering()
	{
		float minSpeedBeforeAllowTurningfactor = carRigidbody2D.velocity.magnitude / 8;

		minSpeedBeforeAllowTurningfactor = Mathf.Clamp01(minSpeedBeforeAllowTurningfactor);

		rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningfactor;
		carRigidbody2D.MoveRotation(rotationAngle);
	}

	private void ApplyEngineForce()
	{
		Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;
		carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
	}

	void KillOrthogonalVelocity()
	{
		Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
		Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);

		carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
	}
}
