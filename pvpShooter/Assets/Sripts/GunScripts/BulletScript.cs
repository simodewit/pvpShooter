using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    #region variables

    [Header("gets this info from gun")]
    public int damage;
    public float speed;

    public float timeToDie, killTime;
    //privates

    #endregion

    #region start

    public void Start()
    {
        killTime = timeToDie + Time.time;
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    #endregion

    #region collision check

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthScript>() != null)
        {
            Debug.Log("Enemy Hit");
            collision.gameObject.GetComponent<HealthScript>().Health(damage);
        }

        Destroy(gameObject);
    }

    public void Update()
    {
        if (killTime < Time.time)
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
