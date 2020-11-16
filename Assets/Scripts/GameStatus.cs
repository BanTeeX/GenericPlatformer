using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
	[SerializeField] private int currentScore = 0;
	[SerializeField] private int pointsPerCoin = 10;
	[SerializeField] private TextMeshProUGUI scoreText;

	private void Start()
	{
		scoreText.text = currentScore.ToString();
	}

	public void ResetPoints() 
	{
		currentScore = 0;
	}

	public void AddToScore()
	{
		currentScore += pointsPerCoin;
		scoreText.text = currentScore.ToString();
	}
}
