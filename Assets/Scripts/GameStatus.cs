using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerCoin = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void resetPoints() 
    {
        currentScore = 0;
    }

    public void AddToScore()
    {
        currentScore += pointsPerCoin;
        scoreText.text = currentScore.ToString();
    }
}
