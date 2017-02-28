using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public Animation animation;
    public const float stopDistance = 1f;

    Vector3[] randomPosition;
    Vector3 startPosition;
    private float randomDistance = 3f;
    private bool isRandomWalk;
    private int randomIndex;

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	    animation = GetComponentInChildren<Animation>();
	    startPosition = transform.position;


        randomPosition = new Vector3[5];
        randomPosition[0] = new Vector3(startPosition.x - randomDistance, startPosition.y, startPosition.z);
        randomPosition[1] = new Vector3(startPosition.x, startPosition.y, startPosition.z + randomDistance);
        randomPosition[2] = new Vector3(startPosition.x + randomDistance, startPosition.y, startPosition.z);
        randomPosition[3] = new Vector3(startPosition.x, startPosition.y, startPosition.z - randomDistance);
        randomPosition[4] = startPosition;

	    StartCoroutine(CoTryDetectTarget());
	    StartCoroutine(CoWalk());
    }

    IEnumerator CoTryDetectTarget()
    {
        while (true)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance <= 5f)
            {
                isRandomWalk = false;
            }
            else
            {
                isRandomWalk = true;
            }
            yield return null;
        }
    }

    IEnumerator CoWalk()
    {
        while (true)
        {
            if (isRandomWalk)
            {
                agent.SetDestination(randomPosition[randomIndex]);
                agent.stoppingDistance = stopDistance;

                if (0 < agent.desiredVelocity.magnitude)
                {
                    animation.CrossFade("Walk");
                }
                else
                {
                    randomIndex = Random.Range(0, randomPosition.Length);
                    animation.CrossFade("Idle1");
                }
            }
            else
            {
                agent.SetDestination(target.position);
                agent.stoppingDistance = stopDistance;

                if (0 < agent.desiredVelocity.magnitude)
                {
                    animation.CrossFade("Walk");
                }
                else
                {
                    if (agent.stoppingDistance <= stopDistance)
                    {
                        animation.CrossFade("Attack1h1");
                    }
                    else
                    {
                        animation.CrossFade("Idle1");
                    }
                }
            }

            yield return null;
        }
    }
}
