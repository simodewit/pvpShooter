using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieLikeEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform player;
    public Animator animator;

    public void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    public void Update()
    {
        agent.SetDestination(player.position); 
        if (agent.velocity.magnitude > 0.5f)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        if (Vector3.Distance(player.position, transform.position) < 2)
        {
            animator.SetTrigger("Attack");
        }
    }

}
