using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
	private Animator animator;
	private Rigidbody2D _rigidbody;
	private CharacterMovement controller;
	private bool isJumping;
	private bool isFalling;
	private bool isMoving;
	private bool isFliped;

	private void Start()
	{
		animator = GetComponent<Animator>();
		_rigidbody = GetComponent<Rigidbody2D>();
		controller = GetComponent<CharacterMovement>();
	}

	private void Update()
	{
		animator.SetBool("isJumping", isJumping);
		animator.SetBool("isFalling", isFalling);
		animator.SetBool("isMoving", isMoving);
		animator.SetBool("isGrounded", controller.IsGrounded);
		GetComponent<SpriteRenderer>().flipX = isFliped;
	}

	private void FixedUpdate()
	{
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
		if (Mathf.Abs(_rigidbody.velocity.x) > 0.1)
		{
			isMoving = true;
			if (_rigidbody.velocity.x < 0 ^ controller.IsGravityInverted)
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
}
