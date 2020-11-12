using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class coinPicking : MonoBehaviour
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
