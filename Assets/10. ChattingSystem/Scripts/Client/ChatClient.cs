using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System;

public class ChatClient : MonoBehaviour {
    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;

    public bool ConnectToServer(string host, int port)
    {
        if (socketReady)
            return false;

        try
        {
            socket = new TcpClient(host, port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);

            socketReady = true;
        }
        catch(Exception e)
        {
            Debug.Log("Socket error : " + e.Message);
        }

        return socketReady;
    }

	void Update ()
    {
        if (socketReady)
        {
            if(stream.DataAvailable)
            {
                string data = reader.ReadLine();
                if(data != null)
                {
                    OnIncomingData(data);
                }
            }
        }
	}

    // Sending messaged to the server
    public void Send(string data)
    {
        if (!socketReady)
            return;

        writer.WriteLine(data);
        writer.Flush();
    }

    // Read message from the server
    private void OnIncomingData(string data)
    {
        string[] aData = data.Split('|');

        switch (aData[0])
        {
            case "SWHO":
                for (int i = 0; i < aData.Length; i++)
                {
                    UserConnected(aData[i], false);
                }
                //Send("CWHO|" + clientName + "|" + ((isHost) ? 1 : 0).ToString());
                //Send("CWHO|" + "TestClientName" + "|" + ((isHost) ? 1 : 0).ToString());
                break;
            case "SCNN":
                UserConnected(aData[1], false);
                break;
            case "SMOV":

                break;
            case "SMSG":

                break;
        }
    }

    private void UserConnected(string name, bool host)
    {
        
    }

    private void OnApplicationQuit()
    {
        CloseSocket();
    }

    private void OnDisable()
    {
        CloseSocket();
    }

    private void CloseSocket()
    {
        if (!socketReady)
            return;

        writer.Close();
        reader.Close();
        socket.Close();
        socketReady = false;
    }
}

public class GameClient
{
    public string name;
    public bool isHost;
}