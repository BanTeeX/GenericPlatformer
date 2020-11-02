using UnityEngine;

public class CharacterMovement : MonoBehaviour, IGravityChangeable
{
	public bool IsGrounded { get; private set; }
	public bool IsGravityInverted { get; set; }

	[SerializeField] private float jumpForce;
	[SerializeField] private float moveSpeed;
	[SerializeField] private Transform chceckGround;
	[SerializeField] private float checkGroundRadius;
	[SerializeField] private LayerMask whatIsGround;
	[SerializeField] private bool airControl;
	[SerializeField] private float moveSmooth;

	private Vector2 velocity = Vector2.zero;
	private Rigidbody2D _rigidbody;
	private float horizontalVelocity;
	private bool jump;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		horizontalVelocity = Input.GetAxisRaw("Horizontal") * moveSpeed;
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
			Vector2 targetVelocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
			_rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref velocity, moveSmooth);
		}
		if (jump && IsGrounded)
		{
			_rigidbody.AddForce(new Vector2(0, jumpForce));
			jump = false;
		}
	}

	public void OnGravityChange()
	{
		IsGravityInverted = !IsGravityInverted;
		_rigidbody.gravityScale *= -1;
		_rigidbody.rotation += 180;
		jumpForce *= -1;
	}
}
