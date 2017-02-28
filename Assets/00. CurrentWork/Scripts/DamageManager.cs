using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager
{
    private static DamageManager instance;
    private Dictionary<string, float> damages = new Dictionary<string, float>();

    public static DamageManager Instance
    {
        get
        {
            return instance;
        }
    }

    static DamageManager()
    {
        if (instance == null)
        {
            instance = new DamageManager();
        }

    }

    void AddDamage(string key, float damage)
    {
        damages[key] = damage;
    }
}
