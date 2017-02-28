using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server
{
    public enum Name
    {
        Azshara,
        Dalaran,
        Doomhammer,
        Zuljin,
    }

    private static readonly Dictionary<Name, string> mServerNames = new Dictionary<Name, string>();
    private static readonly Dictionary<Name, string> mServerAddress = new Dictionary<Name, string>();

    static Server()
    {
        string[] names = System.Enum.GetNames(typeof(Server.Name));
        for (int i = 0; i < names.Length; i++)
        {
            mServerNames.Add((Server.Name)i, names[i]);
        }

        mServerAddress.Add(Name.Azshara, "127.0.0.1");
        mServerAddress.Add(Name.Dalaran, "127.0.0.1");
        mServerAddress.Add(Name.Doomhammer, "127.0.0.1");
        mServerAddress.Add(Name.Zuljin, "127.0.0.1");
    }

    static string GetName(Name name)
    {
        return mServerNames[name];
    }

    static string GetAddresss(Name name)
    {
        return mServerAddress[name];
    }
}