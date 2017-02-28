using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string UserName;
    public int Level;
    public Server.Name ServerKind;
    public Camp.Name CampKind;
    public Races.Name RacesKind;
    public Sex.Name SexKind;
    public Classes.Name ClassesKind;

    void Awake()
    {
        ThreatManager.Instance.AddPlayer(GetComponent<Player>());
    }
}
