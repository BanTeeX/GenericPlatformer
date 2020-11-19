using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float jumpForce = 900.0f;
	[SerializeField] private float moveSpeed = 13.0f;
	[SerializeField] private PlayerController playerController;

	private float horizontalVelocity;
	private bool jump;

	private void Update()
	{
		horizontalVelocity = Input.GetAxisRaw("Horizontal") * moveSpeed;
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
	}

	private void FixedUpdate()
	{
		playerController.Move(horizontalVelocity);
		if (jump == true)
		{
			playerController.Jump(jumpForce);
			jump = false;
		}
	}
}
