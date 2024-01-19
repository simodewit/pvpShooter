using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttack : MonoBehaviour
{
    public GameObject player;
    public int damage;

    public float hitCooldown;
    private float timeStamp;


    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (timeStamp < Time.time)
        {
            if (other == player.GetComponent<Collider>())
            {
                player.GetComponent<HealthScript>().Health(damage);
                timeStamp = Time.time + hitCooldown;
            }
        }
    }
}
