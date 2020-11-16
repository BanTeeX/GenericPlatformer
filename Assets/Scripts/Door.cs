﻿using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] ButtonSpawner buttonSpawner;
    [SerializeField] GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttonSpawner.spawnButton();
            Player.GetComponent<PlayerController>().isLocked = true;
        }
    }
}
