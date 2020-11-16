using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
	[SerializeField] private List<Sprite> List = new List<Sprite>();
	[SerializeField] private Image max;
	[SerializeField] private Image current;

	private int currentPoints;
	private int maxPoints;

	private void Start()
	{
		maxPoints = GameObject.FindGameObjectsWithTag("Coin").Length;
		max.sprite = List[maxPoints];
		current.sprite = List[currentPoints];
	}

	public void AddPoint()
	{
		currentPoints++;
		current.sprite = List[currentPoints];
	}
}
