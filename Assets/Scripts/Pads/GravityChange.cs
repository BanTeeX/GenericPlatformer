using UnityEngine;

public class GravityChange : MonoBehaviour
{
	private IGravityChangeable gravityChangeable;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		gravityChangeable = collision.GetComponent<IGravityChangeable>();
		if (gravityChangeable != null && collision.isTrigger == false)
		{
			gravityChangeable.OnGravityChange();
		}
	}
}
