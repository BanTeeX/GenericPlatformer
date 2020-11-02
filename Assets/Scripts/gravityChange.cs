using UnityEngine;

public class GravityChange : MonoBehaviour
{
	private IGravityChangeable gravityChangeable;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		gravityChangeable = collision.GetComponent<IGravityChangeable>();
		if (gravityChangeable != null)
		{
			gravityChangeable.OnGravityChange();
		}

		//if (collision.CompareTag("Player"))
		//{
		//	GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale *= -1;
		//	GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().rotation += 180;
		//	FindObjectOfType<CharacterMovement>().jumpForce *= -1;
		//}
	}
}
