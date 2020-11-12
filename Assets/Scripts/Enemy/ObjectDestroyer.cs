using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
	private IDestroyable destroyable;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		destroyable = collision.GetComponent<IDestroyable>();
		if (destroyable != null)
		{
			destroyable.DestroyObject();
		}
	}
}
