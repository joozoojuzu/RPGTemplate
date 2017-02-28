using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {
    public float sinkSpeed = 2.5f;

    bool isDead;
    CapsuleCollider capsuleCollider;
    void Start () {
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;
    }
}
