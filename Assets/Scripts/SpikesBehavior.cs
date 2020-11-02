using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesBehavior : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else
		{
			Destroy(collision);
		}
	}
}
