using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public GameObject player, xrRig;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        xrRig = GameObject.FindWithTag("XrRig");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == xrRig)
        {
            player.GetComponent<HealthScript>().isHealing = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == xrRig)
        {
            player.GetComponent<HealthScript>().isHealing = false;
        }
    }
}
