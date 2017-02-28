using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour {

    public GameObject messagePrefab;
    public Transform chatMessageContainer;
    public ChatServer server;
    public ChatClient client;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HostButton()
    {
        try
        {
            ChatServer s = Instantiate(server).GetComponent<ChatServer>();
            s.Init();

            ChatClient c = Instantiate(client).GetComponent<ChatClient>();
            c.ConnectToServer("127.0.0.1", 6321);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            throw;
        }
    }

    public void ConnectToServerButton()
    {
        string hostAddress = GameObject.Find("HostInput").GetComponent<InputField>().text;
        if (hostAddress == "")
        {
            hostAddress = "127.0.0.1";
        }

        try
        {
            ChatClient c = Instantiate(client).GetComponent<ChatClient>();
            c.ConnectToServer(hostAddress, 6321);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            throw;
        }
    }

    public void ChatMessage(string msg)
    {
        GameObject go = Instantiate(messagePrefab) as GameObject;
        go.transform.SetParent(chatMessageContainer);

        go.GetComponentInChildren<Text>().text = msg;
    }

    public void SendChatMessage()
    {
        InputField i = GameObject.Find("MessageInput").GetComponent<InputField>();

        if (i.text == "")
            return;

        client.Send("CMSG|" + i.text);

        i.text = "";
    }
}
