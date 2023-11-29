using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    #region variables

    public int damage;
    public bool hasToDecrease;
    public float decreasingDistance;
    public float decreasingFactor;

    Vector3 startPoint;

    #endregion

    #region start and update

    public void Start()
    {
        startPoint = transform.position;
    }

    #endregion

    #region collision check

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<HealthScript>() != null)
        {
            if(hasToDecrease)
            {
                float distance = Vector3.Distance(startPoint, transform.position);

                if(distance <= decreasingDistance)
                {
                    damage -= (int)((distance -= decreasingDistance) * decreasingFactor);
                    other.GetComponent<HealthScript>().Health(damage);
                }
                else
                {
                    other.GetComponent<HealthScript>().Health(damage);
                }
            }
            else
            {
                other.GetComponent<HealthScript>().Health(damage);
            }
        }

        Destroy(gameObject);
    }

    #endregion
}
