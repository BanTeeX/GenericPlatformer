using UnityEngine;

public class PlayerController : MonoBehaviour, IDestroyable, IGravityChangeable, IJumpPadTrigger
{
	[HideInInspector] public bool isLocked;
	[HideInInspector] public bool isGrounded;
	[HideInInspector] public bool isGravityInverted;
	[HideInInspector] public bool isJumping;
	[HideInInspector] public bool isFalling;
	[HideInInspector] public bool isMoving;
	[HideInInspector] public bool isFliped;

	[SerializeField] private float moveSmooth = 0.2f;
	[SerializeField] private bool airControl = true;
	[SerializeField] private Transform chceckGround;
	[SerializeField] private float checkGroundRadius = 0.2f;
	[SerializeField] private LayerMask whatIsGround;
	[SerializeField] private Rigidbody2D _rigidbody;
	[SerializeField] private float jumpSpeedTolerance = 0.1f;
	[SerializeField] private float fallSpeedTolerance = 0.1f;
	[SerializeField] private float moveSpeedTolerance = 1.5f;
	[SerializeField] private SceneLoader sceneLoader;
	[SerializeField] private AudioSource audioSource;

	private Vector2 velocity = Vector2.zero;

	private void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(chceckGround.position, checkGroundRadius, whatIsGround) != null;
		isJumping = _rigidbody.velocity.y > jumpSpeedTolerance;
		isFalling = _rigidbody.velocity.y < -fallSpeedTolerance;
		isMoving = Mathf.Abs(_rigidbody.velocity.x) > moveSpeedTolerance;
		isFliped = _rigidbody.velocity.x < 0 ^ isGravityInverted;
	}

	public void Move(float speed)
	{
		if (isGrounded == true || airControl == true)
		{
			Vector2 targetVelocity = new Vector2(isLocked ? 0 : speed, _rigidbody.velocity.y);
			_rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref velocity, moveSmooth);
		}
	}

	public void Jump(float jumpForce)
	{
		if (isGrounded == true && isLocked == false)
		{
			audioSource.Play();
			_rigidbody.AddForce(new Vector2(0.0f, (isGravityInverted ? -1.0f : 1.0f) * jumpForce));
		}
	}

	public void DestroyObject()
	{
		sceneLoader.LoadCurrentScene();
	}

	public void OnGravityChange()
	{
		isGravityInverted = !isGravityInverted;
		_rigidbody.gravityScale *= -1;
		_rigidbody.rotation += 180;
	}

	public void OnJumpPadActivation(Vector2 jumpVector)
	{
		_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
		_rigidbody.AddForce(jumpVector);
	}
}
