﻿using UnityEngine;

public class BulletDestroy : MonoBehaviour, IDestroyable
{
	[SerializeField] private float lifeTime = 10;

	private float currentTime = 0;

	private void Update()
	{
		if (lifeTime < currentTime)
		{
			DestroyObject();
		}
		currentTime += Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		DestroyObject();
	}

	public void DestroyObject()
	{
		Destroy(gameObject);
	}
}