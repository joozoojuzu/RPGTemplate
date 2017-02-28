using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Skeleton : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walk,
        Attack,
        Hit,
    }
    public float detectionMaxDistance = 15f;
    public float targetToDistance;
    public Transform detectionTarget;
    public string[] clipNames = new string[System.Enum.GetNames(typeof(State)).Length];
    public State animationState = State.Idle;
    public Animation animation;
    public Transform initTarget;
    public Vector3 startPosition;
    public Vector3[] randomPosition;// = new Vector3[4];
    public float randomDistance = 1f;
    public GameObject[] buff = new GameObject[10];
    public GameObject[] debuff = new GameObject[10];

    void Start()
    {
        animation = GetComponentInChildren<Animation>();

        clipNames[(int)State.Idle] = "Idle1";
        clipNames[(int)State.Walk] = "Walk";
        clipNames[(int)State.Attack] = "Attack1h1";
        clipNames[(int)State.Hit] = "Hit1";

        StartCoroutine(ChangeAnimation());

        GetComponent<SphereCollider>().radius = detectionMaxDistance;

        initTarget = transform;
        startPosition = initTarget.position;

        randomPosition = new Vector3[5];

        randomPosition[0] = new Vector3(startPosition.x - randomDistance, startPosition.y, startPosition.z);
        randomPosition[1] = new Vector3(startPosition.x, startPosition.y, startPosition.z + randomDistance);
        randomPosition[2] = new Vector3(startPosition.x + randomDistance, startPosition.y, startPosition.z);
        randomPosition[3] = new Vector3(startPosition.x, startPosition.y, startPosition.z - randomDistance);
        randomPosition[4] = startPosition;

        StartCoroutine(RandomPosition());
    }

    int randomIndex = 0;
    IEnumerator RandomPosition()
    {
        while (true)
        {
            if (!detectionTarget)
            {
                if (randomPosition[randomIndex] != transform.position)
                    StartWalk(randomPosition[randomIndex]);
                else
                {
                    randomIndex = Random.Range(0, randomPosition.Length);
                }
            }
            yield return null;
        }
    }

    bool isPlaying;
    IEnumerator ChangeAnimation()
    {
        isPlaying = true;
        while (isPlaying)
        {
            switch(animationState)
            {
                case State.Idle:
                    {
                        animation.CrossFade(clipNames[(int)State.Idle]);
                        break;
                    }
                case State.Walk:
                    {
                        animation.CrossFade(clipNames[(int)State.Walk]);
                        break;
                    }
                case State.Attack:
                    {
                        animation.CrossFade(clipNames[(int)State.Attack]);
                        break;
                    }
                case State.Hit:
                    {
                        animation.CrossFade(clipNames[(int)State.Hit]);
                        yield return new WaitForSeconds(0.62f);
                        animationState = previousState;
                        //ChangeAction(animationState);
                        ChangeAction(State.Walk);
                        break;
                    }
            }
            yield return null;
        }
    }

    private State previousState;
	void Update ()
    {
        //Debugging...
        if(detectionTarget)
        {
            targetToDistance = Vector3.Distance(transform.position, detectionTarget.position);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            StartRotate();
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            StopAllAnimations();
            StopAllAction();
            ChangeAnimation(State.Walk);
            ChangeAction(State.Walk);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            StopAllAnimations();
            StopAllAction();
            ChangeAnimation(State.Attack);
            ChangeAction(State.Attack);
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            previousState = animationState;
            StopAllAnimations();
            //StopAllAction();
            ChangeAnimation(State.Hit);
            ChangeAction(State.Hit);
        }

    }

    void StartRotate()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 90f, 0));
        StartCoroutine(Rotation(gameObject, rotation, 3f));
    }

    IEnumerator Rotation(GameObject target, Quaternion newRotation, float duration)
    {
        Quaternion currentRotation = target.transform.rotation;
        newRotation = Quaternion.Euler(target.transform.eulerAngles + newRotation.eulerAngles);

        float counter = 0;
        while(counter < duration)
        {
            counter += Time.deltaTime;
            target.transform.rotation = Quaternion.Lerp(currentRotation, newRotation, counter / duration);
            yield return null;
        }
    }

    void StartWalk(Vector3 to)
    {
        StartCoroutine(Walk(gameObject, to, 3f));
    }

    IEnumerator Walk(GameObject from, Vector3 to, float duration)
    {
        Vector3 currentPosition = from.transform.position;
        Vector3 heading = to - currentPosition; heading.y = 0;
        float distance = heading.magnitude;
        Vector3 dir = heading / distance; from.transform.forward = dir;
        Vector3 newPosition = currentPosition + from.transform.forward * distance;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            if (detectionTarget)
            {
                if (Vector3.Distance(detectionTarget.position, from.transform.position) < 1.2f)
                {
                    from.transform.position = from.transform.position;

                    if (animationState != State.Hit)
                        ChangeAnimation(State.Attack);

                    break;
                }
                else
                {
                    from.transform.position = Vector3.MoveTowards(currentPosition, newPosition, counter / duration);

                    if (animationState != State.Hit)
                        ChangeAnimation(State.Walk);
                }
            }
            else
            {
                from.transform.position = Vector3.MoveTowards(currentPosition, newPosition, counter / duration);

                if (animationState != State.Hit)
                    ChangeAnimation(State.Walk);
            }
            yield return null;
        }

        if (detectionTarget)
            ChangeAnimation(State.Attack);
        else
            ChangeAnimation(State.Idle);
    }

    void ChangeAnimation(State state)
    {
        animationState = state;
        StartCoroutine("ChangeAnimation");
    }

    void ChangeAction(State state)
    {
        switch(state)
        {
            case State.Walk:
                {
                    if(detectionTarget)
                    {
                        StartWalk(detectionTarget.position);
                    }
                    else
                    {
                        StartWalk(startPosition);
                    }
                    break;
                }
        }
    }

    void StopAnimation(string animationName)
    {
        if(animation.IsPlaying(animationName))
        {
            animation.Stop();
        }
    }

    void StopAllAnimations()
    {
        for(int i = 0; i < clipNames.Length; i++)
        {
            StopAnimation(clipNames[i]);
        }
    }

    void StopAllAction()
    {
        StopAllCoroutines();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            detectionTarget = other.transform;

            Debug.Log("Skeleton.OnTriggerEnter!");

            StopAllAnimations();
            StopAllAction();
            ChangeAnimation(State.Walk);
            ChangeAction(State.Walk);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            detectionTarget = null;

            Debug.Log("Skeleton.TriggerExit!");

            StopAllAnimations();
            StopAllAction();
            ChangeAnimation(State.Walk);
            ChangeAction(State.Walk);
        }
    }
}
