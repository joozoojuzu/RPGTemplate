using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0, 0, 0);

    bool isDead;
    bool damaged;

	// Use this for initialization
	void Start ()
	{
	    healthSlider.minValue = 0;
	    healthSlider.maxValue = 100;

	    currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
	}

    public void TakeDamage(float amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        Debug.Log("PlayerHealth.TakeDemage : " + currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
    }
}
