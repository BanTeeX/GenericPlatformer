using UnityEngine;

public class CoinPicking : MonoBehaviour
{
	[SerializeField] private GameStatus gameStatus;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			gameStatus.AddToScore();
			Destroy(gameObject);
		}
	}
}
