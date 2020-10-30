using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	public bool IsGrounded { get; private set; }

	[SerializeField] private float jumpForce = 500f;
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private Transform chceckGround;
	[SerializeField] private float checkGroundRadius = 0.1f;
	[SerializeField] private LayerMask whatIsGround;
	[SerializeField] private bool airControl = true;
	//[SerializeField] private float moveSmooth = 0.3f; //manualSmooth

	//private Vector2 velocity = Vector2.zero; //manualSmooth
	private Rigidbody2D _rigidbody;
	private float horizontalVelocity = 0f;
	private bool jump = false;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		//horizontalVelocity = Input.GetAxisRaw("Horizontal") * moveSpeed; //manualSmooth
		horizontalVelocity = Input.GetAxis("Horizontal") * moveSpeed; //autoSmooth
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
	}

	private void FixedUpdate()
	{
		IsGrounded = Physics2D.OverlapCircle(chceckGround.position, checkGroundRadius, whatIsGround);
		if (IsGrounded || airControl)
		{
			//Vector2 targetVelocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y); //manualSmooth
			//_rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref velocity, moveSmooth); //manualSmooth
			_rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y); //autoSmooth
		}
		if (jump && IsGrounded)
		{
			_rigidbody.AddForce(new Vector2(0, jumpForce));
			jump = false;
		}
	}
}
