using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatManager {
    private Dictionary<string, Player> threatPlayers = new Dictionary<string, Player>();

    private static ThreatManager instance;

    public static ThreatManager Instance
    {
        get
        {
            return instance;
        }
    }

    static ThreatManager()
    {
        if (instance == null)
        {
            instance = new ThreatManager();
        }
    }

    public void AddPlayer(Player player)
    {
        Debug.Log("Add Threat Player : " + player.UserName);
        threatPlayers.Add(player.UserName, player);
    }

    public Player GetHighestThreatLevelPlayer()
    {
        return threatPlayers["저리비켜"];
    }
}
