using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float accelerationFactor = 30.0f;
    [SerializeField] float turnFactor = 3.5f;
	[SerializeField] float driftFactor = 0.9f;

    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    Rigidbody2D carRigidbody2D;

	private void Awake()
	{
		carRigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		Game.Instance.GameStarted += OnGameStarted;
		Game.Instance.GameEnded += OnGameEnded;
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
	
		Vector2 inputVector = Vector2.zero;

		inputVector.x = Input.GetAxis("Horizontal");
		inputVector.y = Input.GetAxis("Vertical");

		SetInputVector(inputVector);
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

	public void SetInputVector(Vector2 inputVector)
	{
		steeringInput = inputVector.x;
		accelerationInput = inputVector.y;
	}

	void KillOrthogonalVelocity()
	{
		Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
		Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);

		carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
	}
}
