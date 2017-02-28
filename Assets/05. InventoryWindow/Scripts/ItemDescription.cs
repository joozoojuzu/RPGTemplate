using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    public enum Description
    {
        Name,
        DungeonLevel,
        ItemLevel,
        Wearable,
        WearingLocation,
        Stat,
        Classes,
        RequiredLevel,
        Price,
    }

    public List<Text> descriptions = new List<Text>();

    void Awake()
    {
        descriptions.Capacity = System.Enum.GetNames(typeof (Description)).Length;
    }

    void Start()
    {
        descriptions.Capacity = System.Enum.GetNames(typeof (Description)).Length;
    }
}
