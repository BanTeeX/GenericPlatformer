using UnityEngine;

public class Bullet : MonoBehaviour, IDestroyable
{
	[SerializeField] private float lifeTime = 10.0f;

	private float currentTime = 0;

	private void Update()
	{
		if (lifeTime < currentTime)
		{
			DestroyObject();
		}
		currentTime += Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		DestroyObject();
	}

	public void DestroyObject()
	{
		Destroy(gameObject);
	}
}
