using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {
    public float totalKeepTime = 6f;
    public float onceMoveTime = 2f;

    private bool execute;
	void Start ()
    {
		//ToDo 원주율의 좌표를 계산한다.
	}
	
	void Update ()
    {
	    if (execute)
        {

        }
	}

    public void Execute()
    {
        execute = true;
    }
}
