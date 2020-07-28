using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class ParticlePot : MonoBehaviour
{
	[SerializeField] ParticleSystem particleSystem = null;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			Collect();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Ingredient"))
		{
			Destroy(other.gameObject);
			Collect();
		}
	}

	public void Collect()
	{
		particleSystem.Play();
	}
}
