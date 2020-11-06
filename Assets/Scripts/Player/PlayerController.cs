using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDestroyable, IGravityChangeable
{
	[HideInInspector] public  bool isLocked;
	[HideInInspector] public bool isGrounded;
	[HideInInspector] public bool isGravityInverted;
	[HideInInspector] public bool isJumping;
	[HideInInspector] public bool isFalling;
	[HideInInspector] public bool isMoving;
	[HideInInspector] public bool isFliped;

	[SerializeField] private float moveSmooth = 0.2f;
	[SerializeField] private bool airControl = true;
	[SerializeField] private Transform chceckGround;
	[SerializeField] private float checkGroundRadius;
	[SerializeField] private LayerMask whatIsGround;
	[SerializeField] private Rigidbody2D _rigidbody;

	private Vector2 velocity = Vector2.zero;

	private void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(chceckGround.position, checkGroundRadius, whatIsGround);

		if (_rigidbody.velocity.y > 0.1)
		{
			isJumping = true;
		}
		else
		{
			isJumping = false;
		}
		if (_rigidbody.velocity.y < -0.1)
		{
			isFalling = true;
		}
		else
		{
			isFalling = false;
		}
		if (Mathf.Abs(_rigidbody.velocity.x) > 1.5)
		{
			isMoving = true;
			if (_rigidbody.velocity.x < 0 ^ isGravityInverted)
			{
				isFliped = true;
			}
			else
			{
				isFliped = false;
			}
		}
		else
		{
			isMoving = false;
		}
	}

	public void Move(float horizontalVelocity)
	{
		if (isGrounded || airControl)
		{
			Vector2 targetVelocity = new Vector2(isLocked ? 0.0f : horizontalVelocity, _rigidbody.velocity.y);
			_rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref velocity, moveSmooth);
		}
	}

	public void Jump(float jumpForce, float jumpScale = 1.0f)
	{
		if (isGrounded && !isLocked)
		{
			_rigidbody.AddForce(new Vector2(0, (isGravityInverted ? -1.0f : 1.0f) * jumpForce * jumpScale));
		}
	}

	public void DestroyObject()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OnGravityChange()
	{
		isGravityInverted = !isGravityInverted;
		_rigidbody.gravityScale *= -1;
		_rigidbody.rotation += 180;
	}
}
