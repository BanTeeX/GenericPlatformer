using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private EnemyController enemyController;

	private void Update()
	{
		animator.SetBool("isJumping", enemyController.isJumping);
		animator.SetBool("isFalling", enemyController.isFalling);
		animator.SetBool("isMoving", enemyController.isMoving);
		animator.SetBool("isGrounded", enemyController.isGrounded);
		GetComponent<SpriteRenderer>().flipX = enemyController.isFliped;
	}
}
