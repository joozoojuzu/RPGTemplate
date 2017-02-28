using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLoader
{
    public const string cPrefabDir = "Prefabs/";
    public const string cCharacter = cPrefabDir + "Characters/";
    public const string cMap = cPrefabDir + "Maps/";
    public const string cSkills = cPrefabDir + "Skills/";
    public static GameObject LoadPrefab(string path, string name)
    {
        GameObject obj = Object.Instantiate(Resources.Load(path + name)) as GameObject;
        obj.name = name;

        return obj;
    }

    public static GameObject LoadPrefab(string path, string name, Vector3 position)
    {
        GameObject obj = LoadPrefab(path, name);
        obj.transform.position = position;

        return obj;
    }
}
