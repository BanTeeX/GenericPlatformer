using UnityEngine;

public class EnemyController : MonoBehaviour, IGravityChangeable, IJumpPadTrigger, IDestroyable
{
	[SerializeField] private float speed;
	[SerializeField] private Rigidbody2D _rigidbody;

	private bool isFlip;
	private RaycastHit2D[] raycastHit;

	private void FixedUpdate()
	{
		raycastHit = Physics2D.RaycastAll(transform.position, isFlip ? Vector2.left : Vector2.right, 0.7f);
		if (raycastHit.Length == 2)
		{
			isFlip = !isFlip;
		}
		_rigidbody.velocity = new Vector2(isFlip ? -speed : speed, _rigidbody.velocity.y);
	}

	public void DestroyObject()
	{
		Destroy(gameObject);
	}

	public void OnGravityChange()
	{
		_rigidbody.gravityScale *= -1;
		_rigidbody.rotation += 180;
	}

	public void OnJumpPadActivation(Vector2 jumpVector)
	{
		_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
		_rigidbody.AddForce(jumpVector);
	}
}
