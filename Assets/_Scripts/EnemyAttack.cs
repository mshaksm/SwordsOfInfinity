using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	private AudioSource noise;

    private void Awake()
    {
		//get audiosource component
		noise = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag("Player"))
		{
			//player takes 10 damage to health and play enemy hit sound
			other.GetComponent<StatusC>().TakeDamage(10);
			noise.Play();

		}
	}
}
