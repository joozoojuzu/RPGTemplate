using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes
{
    private static readonly Dictionary<Name, string> mClasses = new Dictionary<Name, string>();
    public enum Name
    {
        Warrior,        // 전사
        Paladin,        // 성기사
        Hunter,         // 사냥꾼
        Rogue,          // 도적
        Priest,         // 사제
        DeathKnight,    // 죽음의기사
        Shaman,         // 주술사
        Mage,           // 마법사
        Warlock,        // 흑마법사
        Monk,           // 수도사
        Druid,          // 드루이드
        DemonHunter     // 악마사냥군
    }

    static Classes()
    {
        string[] names = System.Enum.GetNames(typeof(Classes.Name));
        for (int i = 0; i < names.Length; i++)
        {
            mClasses.Add((Classes.Name)i, names[i]);
        }
    }

    public static string GetName(Name name)
    {
        return mClasses[name];
    }
}