using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] private GameObject bullet;
	[SerializeField] private float bulletSpeed = 10f;
	[SerializeField] private float timeBetweenShoot = 10f;
	
	private void Start()
	{
		StartCoroutine(Fire());
	}

	private IEnumerator Fire()
	{
		while (true)
		{
			GameObject oneBullet = Instantiate(bullet, transform.position, Quaternion.identity);
			oneBullet.GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector2.left * bulletSpeed;
			yield return new WaitForSeconds(timeBetweenShoot);
		}
	}
}
