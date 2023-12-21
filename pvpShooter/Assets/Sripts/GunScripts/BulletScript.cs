using Photon.Pun;
using System;
using UnityEngine;

public class BulletScript : MonoBehaviourPunCallbacks
{
    #region variables

    [Header("gets this info from gun")]
    public int damage;
    public bool hasToDecrease;
    public float decreasingDistance;
    public float decreasingFactor;

    //privates
    Vector3 startPoint;

    #endregion

    #region start

    public void Start()
    {
        startPoint = transform.position;
    }

    #endregion

    #region collision check

    public void OnCollisionEnter(Collision collision)
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

    #endregion
}
