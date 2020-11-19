using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] private MenuController menuController;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") == true)
		{
			menuController.ActivateMenu();
			collision.GetComponent<PlayerController>().isLocked = true;
		}
	}
}
