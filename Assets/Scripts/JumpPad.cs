using UnityEngine;

public class JumpPad : MonoBehaviour
{
	[SerializeField] private float jumpForce;

	private IMoveable moveable;

	public void OnTriggerStay2D(Collider2D collision)
	{
		moveable = collision.GetComponent<IMoveable>();
		if (moveable != null)
		{
			moveable.Jump(jumpForce);
		}
	}
}
