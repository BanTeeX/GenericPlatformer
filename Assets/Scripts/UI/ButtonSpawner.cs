using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{   
	[SerializeField] private Canvas Canvas;
	[SerializeField] private GameStatus GameStatus;

	public void SpawnButton()
	{
		Instantiate(Canvas, Camera.main.transform.position, Quaternion.identity);
		Instantiate(GameStatus, Camera.main.transform.position, Quaternion.identity);
	}
}
