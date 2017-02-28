using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public GameObject inventoryWindow;

    void Awake()
    {
        inventoryWindow = GameObject.Find("InventoryWindow");
    }

    void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryWindow.SetActive(!inventoryWindow.activeSelf);
        }
	}
}
