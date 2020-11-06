using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{   
    [SerializeField] Canvas Canvas;

    public void spawnButton()
    {
        Instantiate(Canvas, Camera.main.transform.position, Quaternion.identity);
    }

}
