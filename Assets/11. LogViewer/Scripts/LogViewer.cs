using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogViewer : MonoBehaviour {

    private static LogViewer instance;
    public static LogViewer Instance
    {
        get { return instance; }
    }

    private const int maxMessage = 512;
    private Queue<GameObject> messageQueue = new Queue<GameObject>(maxMessage);
    private static int dataCountInLogViewer;

    public Transform logContainer;
    public GameObject logMessage;

    void Awake()
    {
        instance = this;


        GameObject msgObject;
        for( int i = 0; i < maxMessage; i++ )
        {
            msgObject = Instantiate(logMessage) as GameObject;
            msgObject.transform.SetParent(logContainer);
            msgObject.transform.localScale = Vector3.one;

            msgObject.GetComponentInChildren<Text>().text = "";
            messageQueue.Enqueue(msgObject);
        }
    }

    void FixedUpdate()
    {
    }

    //public void Add(string message, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
    public void Add(string message)
    {
        GameObject msgObject = messageQueue.Dequeue();
        logContainer.gameObject.AddChild(msgObject);
        msgObject.name = "" + (++dataCountInLogViewer);

        string msg = message + " : " + dataCountInLogViewer;
        msgObject.GetComponentInChildren<Text>().text = msg;
        messageQueue.Enqueue(msgObject);
    }
}
