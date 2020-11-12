using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{   
    [SerializeField] Canvas Canvas;
    [SerializeField] GameStatus GameStatus;

    public void spawnButton()
    {
        Instantiate(Canvas, Camera.main.transform.position, Quaternion.identity);
        Instantiate(GameStatus, Camera.main.transform.position, Quaternion.identity);
    }

}
