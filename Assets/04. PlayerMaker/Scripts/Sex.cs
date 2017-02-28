using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sex
{
    private static readonly Dictionary<Name, string> mSex = new Dictionary<Name, string>();
    public enum Name
    {
        Male,
        Female,
    }

    static Sex()
    {
        string[] names = System.Enum.GetNames(typeof(Sex.Name));
        for (int i = 0; i < names.Length; i++)
        {
            mSex.Add((Sex.Name)i, names[i]);
        }
    }

    static string GetName(Name name)
    {
        return mSex[name];
    }
}