using UnityEngine;

public class JumpPad : MonoBehaviour
{
	[SerializeField] private float jumpForce;
	[SerializeField] private AudioSource audioSource;

	private IJumpPadTrigger moveable;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		moveable = collision.GetComponent<IJumpPadTrigger>();
		if (moveable != null && collision.isTrigger == false)
		{
			audioSource.Play();
			Vector2 jumpVector = transform.rotation * Vector2.up * jumpForce;
			moveable.OnJumpPadActivation(jumpVector);
		}
	}
}
