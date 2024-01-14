using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : MonoBehaviour
{
    public GameObject entireEnemy;
    public GameObject deathParticle;
    public void Hit()
    {
        print("Headshot");
        FindAnyObjectByType<SpawnEnemy>().enemies.Remove(gameObject);
        Instantiate(deathParticle, transform.position, transform.rotation);
        Destroy(entireEnemy);
    }
}
