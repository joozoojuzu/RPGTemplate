using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetStateUIZone : MonoBehaviour {
    public Slider targetHealthSlider;
    public Health targetHealth;

	void Update ()
    {
	    if(targetHealth)
        {
            targetHealthSlider.value = targetHealth.currentHealth;
        }
	}

    private void Show()
    {
        gameObject.SetActive(true);
    }

    public void Show(Health health)
    {
        Show();
        targetHealth = health;
    }

    public void Hide()
    {
        targetHealth = null;
        gameObject.SetActive(false);
    }
}
