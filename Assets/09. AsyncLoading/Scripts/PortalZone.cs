using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalZone : MonoBehaviour {
    public AsyncLoadScene loadScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            loadScreen.LoadingScreen();
        }
    }
}
