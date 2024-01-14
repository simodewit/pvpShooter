using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieLikeEnemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public void Start()
    {
        agent.SetDestination(GameObject.FindWithTag("Player").transform.position); 
    }
}
