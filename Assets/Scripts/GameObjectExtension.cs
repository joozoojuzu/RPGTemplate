using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtension
{
    public static void AddChild(this GameObject parent, GameObject child)
    {
        child.transform.SetParent(null);
        child.transform.SetParent(parent.transform);
        child.transform.localScale = Vector3.one;
        child.transform.localPosition = Vector3.zero;
    }

    public static void AddChild(this GameObject parent, GameObject child, Vector3 position)
    {
        AddChild(parent, child);
        child.transform.position = position;
    }

    public static void AddChild(this GameObject parent, GameObject child, Vector3 position, Vector2 widthAndHeight)
    {
        AddChild(parent, child, Vector3.zero);
        child.transform.position = position;
        RectTransform rectTransform = child.GetComponent<RectTransform>();
        if (rectTransform)
        {
            rectTransform.sizeDelta = widthAndHeight;
        }
    }

    public static void AddChild(this GameObject parent, GameObject child, Vector3 position, Vector3 eulerAngles)
    {
        AddChild(parent, child, position);
        child.transform.eulerAngles = eulerAngles;
    }
}
