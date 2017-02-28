using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp
{
    private static readonly Dictionary<Name, string> mCamp = new Dictionary<Name, string>();
    public enum Name
    {
        Horde,
        Alliance,
    }

    static Camp()
    {
        string[] names = System.Enum.GetNames(typeof(Camp.Name));
        for (int i = 0; i < names.Length; i++)
        {
            mCamp.Add((Camp.Name)i, names[i]);
        }
    }

    static string GetName(Name name)
    {
        return mCamp[name];
    }
}