using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityChange : MonoBehaviour
{

	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale *= -1; ;
			GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().rotation += 180;
			FindObjectOfType<CharacterMovement>().jumpForce *= -1;
		}
	}

	
}
