using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class CoinPicking : MonoBehaviour
{
    [SerializeField] GameStatus gameStatus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameStatus.AddToScore();
            Destroy(gameObject);
        }
    }
}
