using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public GameObject player;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        print(other);
        if (other.gameObject == player)
        {
            player.GetComponent<HealthScript>().isHealing = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other == player)
        {
            player.GetComponent<HealthScript>().isHealing = false;
        }
    }
}
