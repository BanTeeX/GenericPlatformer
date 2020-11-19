using UnityEngine;

public class CoinPicking : MonoBehaviour
{
	[SerializeField] private GameStatus gameStatus;
	[SerializeField] private GameObject coinSound;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") == true)
		{
			Instantiate(coinSound);
			gameStatus.AddPoint();
			Destroy(gameObject);
		}
	}
}
