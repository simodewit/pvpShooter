using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    #region variables

    [Header("gets this info from gun")]
    public int damage;
    public bool hasToDecrease;
    public float decreasingDistance;
    public float decreasingFactor;

    public float timeToDie, killTime;
    //privates
    Vector3 startPoint;

    #endregion

    #region start

    public void Start()
    {
        startPoint = transform.position;
        killTime = timeToDie + Time.time;
    }

    #endregion

    #region collision check

    public void OnCollisionEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<HealthScript>() != null)
        {
            if (hasToDecrease)
            {
                float distance = Vector3.Distance(startPoint, transform.position);

                if (distance <= decreasingDistance)
                {
                    damage -= (int)((distance -= decreasingDistance) * decreasingFactor);
                    collision.gameObject.GetComponent<HealthScript>().Health(damage);
                }
                else
                {
                    collision.gameObject.GetComponent<HealthScript>().Health(damage);
                }
            }
            else
            {
                collision.gameObject.GetComponent<HealthScript>().Health(damage);
            }
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
