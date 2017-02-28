using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Races
{
    private static readonly Dictionary<Name, string> mRaces = new Dictionary<Name, string>();
    public enum Name
    {
        Orc,
        Undead,
        Tauren,
        Troll,
        BloodElf,
        Goblin,

        Human,
        Dwarf,
        NightElf,
        Gnome,
        Draenei,
        Worgen,

        Pandaren,
    }

    static Races()
    {
        string[] names = System.Enum.GetNames(typeof(Races.Name));
        for (int i = 0; i < names.Length; i++)
        {
            mRaces.Add((Races.Name)i, names[i]);
        }
    }

    static string GetName(Name name)
    {
        return mRaces[name];
    }
}