using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieLikeEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    public void Update()
    {
        agent.SetDestination(player.position); 
    }
}
