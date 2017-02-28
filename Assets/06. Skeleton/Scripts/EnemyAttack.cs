using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth playerHealth;

	// Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player");
	    playerHealth = player.GetComponent<PlayerHealth>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerHealth.TakeDamage(10);
        }
    }
}
