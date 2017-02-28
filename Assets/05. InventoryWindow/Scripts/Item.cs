using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    public enum Part
    {
        Head, Necklace, Shoulder, Cloak, Chest, Wrist, Glove, Waist, Pants, Boots
    }

    public enum Grade
    {
        General,
        Hero,
        Legend,
    }

    public enum Wearable
    {
        Eat,
        Wearing,
    }

    public Part part;
    public Grade grade;
    public Wearable wearable;
    public Classes.Name classes;
    public Image icon;

    public string id;
    public string nameString;
    public string dungeonLevelString;
    public string itemLevelString;
    public string wearableString;
    public string locationString;
    public string statString;
    public string classesString;
    public string requireLevelString;
    public string priceString;
}
