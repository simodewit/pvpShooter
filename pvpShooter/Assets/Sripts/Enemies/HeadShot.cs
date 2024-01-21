using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : MonoBehaviour
{
    public GameObject entireEnemy;
    public GameObject deathParticle;
    private AudioSource crowd, commentator;
    private WinGameScript winGame;

    public void Start()
    {
        crowd = GameObject.FindWithTag("Cheer").GetComponent<AudioSource>();
        commentator = GameObject.FindWithTag("HS").GetComponent<AudioSource>();
        winGame = GameObject.FindWithTag("Win").GetComponent<WinGameScript>();
    }
    public void Hit()
    {
        winGame.numbKills += 1;
        winGame.numbHeadshot += 1;
        winGame.OnKill();
        FindAnyObjectByType<SpawnEnemy>().enemies.Remove(entireEnemy.gameObject);
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
