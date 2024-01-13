using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float timeStamp;
    public float cooldown;
    public float bulletSpeed;
    public int damage;
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
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        bullet.GetComponent<BulletScript>().damage = damage;
        bullet.GetComponent<BulletScript>().hasToDecrease = false;
        bullet.GetComponent<BulletScript>().decreasingDistance = 0;
        bullet.GetComponent<BulletScript>().decreasingFactor = 0;
    }
}
