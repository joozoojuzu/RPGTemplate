using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Heeler : MonoBehaviour {
    public GameObject owner;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        owner = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.SetDestination(owner.transform.position);
	}
}
