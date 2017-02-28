using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Onyxia : MonoBehaviour {
    public Player targetPlayer;

    private ThreatManager threatPlayers;
    private bool battleStart;
    private NavMeshAgent agent;

    void Start () {
        threatPlayers = ThreatManager.Instance;
        agent = GetComponent<NavMeshAgent>();
	}
	
	void Update ()
    {
        if (battleStart)
        {
            targetPlayer = threatPlayers.GetHighestThreatLevelPlayer();

            agent.SetDestination(targetPlayer.transform.position);
        }
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            battleStart = !battleStart;
        }
    }

    void GivePanicToPlayers()
    {

    }
}
