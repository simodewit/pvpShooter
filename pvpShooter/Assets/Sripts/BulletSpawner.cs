using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float timeStamp;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStamp < Time.time)
        {
            Shoot();
            timeStamp = Time.time + cooldown;
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
