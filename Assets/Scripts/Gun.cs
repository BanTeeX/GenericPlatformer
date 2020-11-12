using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float timeBetweenShoot = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private IEnumerator Fire()
    {
        while (true)
        {
            GameObject oneBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            oneBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
            yield return new WaitForSeconds(timeBetweenShoot);
        }

        }
    }
