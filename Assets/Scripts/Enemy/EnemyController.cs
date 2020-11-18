using UnityEngine;

public class EnemyController : MonoBehaviour, IGravityChangeable, IJumpPadTrigger, IDestroyable
{
	public bool isFliped;

	[HideInInspector] public bool isGrounded;
	[HideInInspector] public bool isGravityInverted;
	[HideInInspector] public bool isJumping;
	[HideInInspector] public bool isFalling;
	[HideInInspector] public bool isMoving;

	[SerializeField] private float speed = 4.0f;
	[SerializeField] private Transform chceckGround;
	[SerializeField] private float checkGroundRadius = 0.15f;
	[SerializeField] private LayerMask whatIsGround;
	[SerializeField] private Rigidbody2D _rigidbody;
	[SerializeField] private float jumpSpeedTolerance = 0.1f;
	[SerializeField] private float speedTolerance = 0.1f;

	/*[SerializeField]*/ private bool wasOnGravityPad;

	private void Start()
	{
		if (isFliped)
		{
			speed *= -1;
		}
	}

	private void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(chceckGround.position, checkGroundRadius, whatIsGround) != null;
		if (Physics2D.Raycast(transform.position, isFliped ^ isGravityInverted ? Vector2.left : Vector2.right, GetComponent<SpriteRenderer>().bounds.size.x / 2, whatIsGround).collider != null)
		{
			speed *= -1;
		}
		if (wasOnGravityPad == true && isGrounded == false)
		{
			_rigidbody.velocity = new Vector2(_rigidbody.velocity.x / 1.1f, _rigidbody.velocity.y);
			if (isGrounded == true)
			{
				wasOnGravityPad = false;
			}
		}
		else
		{
			_rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
		}

		if (_rigidbody.velocity.y > jumpSpeedTolerance)
		{
			isJumping = true;
		}
		else
		{
			isJumping = false;
		}
		if (_rigidbody.velocity.y < -jumpSpeedTolerance)
		{
			isFalling = true;
		}
		else
		{
			isFalling = false;
		}
		if (Mathf.Abs(_rigidbody.velocity.x) > speedTolerance)
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

	public void DestroyObject()
	{
		Destroy(gameObject);
	}

	public void OnGravityChange()
	{
		isGravityInverted = !isGravityInverted;
		wasOnGravityPad = true;
		_rigidbody.gravityScale *= -1;
		_rigidbody.rotation += 180;
	}

	public void OnJumpPadActivation(Vector2 jumpVector)
	{
		_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
		_rigidbody.AddForce(jumpVector);
	}
}
