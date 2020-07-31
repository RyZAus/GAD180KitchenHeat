﻿using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class ParticlePot : MonoBehaviour
{
	[SerializeField] ParticleSystem particleSystem = null;

	public GameManager gameManager;
	public GameObject ingredient1;
	public GameObject ingredient2;
	public GameObject ingredient3;
	public GameObject ingredient4;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			IngredientIn();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Ingredient"))
		{
			Destroy(other.gameObject);
			IngredientIn();
		}
	}
	public void IngredientIn()
	{
		particleSystem.Play();
		gameManager.scoreUpdate();
	}
}
