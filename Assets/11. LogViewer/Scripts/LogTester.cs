using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTester : MonoBehaviour {
	void Start ()
    {
        StartCoroutine(CoInsertData());
	}

    IEnumerator CoInsertData()
    {
        while(true)
        {
            LogViewer.Instance.Add("Insert Test data ! ");
            yield return null;
        }
    }
	
    /*
	void FixedUpdate () {
        logViewer.Add("Insert Test data ! ");
	}
    */
}
