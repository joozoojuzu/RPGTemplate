using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using System.Net;
using System.IO;

public class ChatServer : MonoBehaviour {
    public int port = 6321;

    private List<ServerClient> clients;
    private List<ServerClient> disconnectList;

    private TcpListener server;
    private bool serverStarted;

    public void Init()
    {
        DontDestroyOnLoad(gameObject);

        clients = new List<ServerClient>();
        disconnectList = new List<ServerClient>();

        try
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
        }
        catch (Exception e)
        {
            Debug.Log("Socket Error : " + e.Message);
        }
    }

    private void Start()
    {

        try
        {

            StartListening();
            serverStarted = true;

            Debug.Log("Server has been started on port : " + port.ToString());
        }
        catch(Exception e)
        {
        }
    }

    private void Update()
    {
        if (!serverStarted)
            return;

        foreach(ServerClient c in clients)
        {
            if (!IsConnected(c.tcp))
            {
                c.tcp.Close();
                disconnectList.Add(c);
                continue;
            }
            else
            {
                NetworkStream s = c.tcp.GetStream();
                if (s.DataAvailable)
                {
                    StreamReader reader = new StreamReader(s, true);
                    string data = reader.ReadLine();

                    if (data != null)
                    {
                        OnIncomingData(c, data);
                    }
                }
            }
        }

        for (int i = 0; i < disconnectList.Count - 1; i++)
        {
            clients.Remove(disconnectList[i]);
            disconnectList.RemoveAt(i);
        }
    }

    private void StartListening()
    {
        server.BeginAcceptTcpClient(AcceptTcpClient, server);
    }

    private bool IsConnected(TcpClient c)
    {
        try
        {
            if (c != null && c.Client != null && c.Client.Connected)
            {
                if (c.Client.Poll(0, SelectMode.SelectRead))
                {
                    return !(c.Client.Receive(new Byte[1], SocketFlags.Peek) == 0);
                }
                return true;
            }
            else
                return false;
        }
        catch(Exception e)
        {
            return false;
        }
    }

    // Server Send
    private void Broadcast(string data, List<ServerClient> clients)
    {
        foreach(ServerClient sc in clients)
        {
            try
            {
                StreamWriter writer = new StreamWriter(sc.tcp.GetStream());
                writer.WriteLine(data);
                writer.Flush();
            }
            catch(Exception e)
            {
                Debug.Log("Write error : " + e.Message);
            }
        }
    }
    // Server Read
    private void AcceptTcpClient(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener)ar.AsyncState;

        ServerClient sc = new ServerClient(listener.EndAcceptTcpClient(ar));
        clients.Add(sc);

        StartListening();

        Debug.Log("Somebody has connected!");
    }
    private void OnIncomingData(ServerClient c, string data)
    {
        Debug.Log("Server > " + c.clientName + "has sent the following message : " + data);
        string[] aData = data.Split('|');

        switch (aData[0])
        {
            case "CWHO":
                c.clientName = aData[1];
                c.isHost = (aData[2] == "0") ? false : true;
                Broadcast("SCNN|" + c.clientName, clients);
                break;
            case "CMOV":
                Broadcast("SMOV|" + aData[1] + "|" + aData[2] + "|" + aData[3] + "|" + aData[4], clients);
                break;
            case "CMSG":
                Broadcast("SMSG|" + c.clientName + " : " + aData[1], clients);
                break;
        }
    }
}

public class ServerClient
{
    public TcpClient tcp;
    public string clientName;
    public bool isHost;

    public ServerClient(TcpClient tcp)
    {
        clientName = "Guest";
        this.tcp = tcp;
    }
}