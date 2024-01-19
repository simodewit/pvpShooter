using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : MonoBehaviour
{
    public GameObject entireEnemy;
    public GameObject deathParticle;
    private AudioSource crowd, commentator;

    public void Start()
    {
        crowd = GameObject.FindWithTag("Cheer").GetComponent<AudioSource>();
        commentator = GameObject.FindWithTag("HS").GetComponent<AudioSource>();

    }
    public void Hit()
    {
        FindAnyObjectByType<SpawnEnemy>().enemies.Remove(transform.parent.gameObject);
        Instantiate(deathParticle, transform.position, transform.rotation);
        Destroy(entireEnemy);

        if (commentator.isPlaying == false)
        {
            commentator.Play();

        }
        if (crowd.isPlaying == false)
        {
            crowd.Play();
        }
    }
}
