using UnityEngine;

public class GravityChange : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;

	private IGravityChangeable gravityChangeable;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		gravityChangeable = collision.GetComponent<IGravityChangeable>();
		if (gravityChangeable != null && collision.isTrigger == false)
		{
			audioSource.Play();
			gravityChangeable.OnGravityChange();
		}
	}
}
