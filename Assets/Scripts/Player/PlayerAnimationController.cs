using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private PlayerController playerController;

	private void Update()
	{
		animator.SetBool("isJumping", playerController.isJumping);
		animator.SetBool("isFalling", playerController.isFalling);
		animator.SetBool("isMoving", playerController.isMoving);
		animator.SetBool("isGrounded", playerController.isGrounded);
		GetComponent<SpriteRenderer>().flipX = playerController.isFliped;
	}
}
