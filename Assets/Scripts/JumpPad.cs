using UnityEngine;

public class JumpPad : MonoBehaviour
{
	[SerializeField] private float jumpForce;

	private IJumpPadTrigger moveable;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		moveable = collision.GetComponent<IJumpPadTrigger>();
		if (moveable != null)
		{
			Vector2 jumpVector = transform.rotation * Vector2.up * jumpForce;
			moveable.OnJumpPadActivation(jumpVector);
		}
	}
}
