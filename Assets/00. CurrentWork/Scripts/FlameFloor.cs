using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFloor : MonoBehaviour {
    public GameObject player;
    private PlayerHealth health;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("FlameFloor.OnCollisionEnter !");
            health.TakeDamage(1f);
        }
    }
}
