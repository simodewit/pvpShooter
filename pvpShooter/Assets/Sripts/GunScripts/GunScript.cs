using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class GunScript : MonoBehaviour
{
    #region variables

    [Header("Gun details (1 is primary, 2 is secondary, 3 is melee weapon)")]
    public int weaponType;

    [Header("General conditions")]
    public float range;
    public float damage;
    public bool decreasingDamageByRange;
    public bool automaticGun;

    [Header("SplashDamage")]
    public bool splashDamage;
    public float splashDamageRange;

    [Header("refrences")]
    public Transform endOfBarrel;

    //private variables
    PhotonView view;
    RaycastHit rayHit;
    bool hasFired;

    Debugger debugger;

    #endregion

    #region start and update

    public void Start()
    {
        view = GetComponent<PhotonView>();
        debugger = GameObject.Find("DebugTool").GetComponent<Debugger>();
    }

    #endregion

    #region inputs

    public void Inputs()
    {
        if(!view.IsMine)
        {
            return;
        }

        if (automaticGun)
        {
            Shoot();
        }
        else
        {
            if(!hasFired)
            {
                Shoot();
                hasFired = true;
            }
        }
    }

    public void StopInput()
    {
        hasFired = false;
    }

    #endregion

    #region shoot code

    [PunRPC]
    public void Shoot()
    {
        if (!view.IsMine)
        {
            return;
        }

        debugger.VrPrint("shoot");

        if (Physics.Raycast(endOfBarrel.position, transform.forward, out rayHit, range))
        {
            if (splashDamage)
            {
                Collider[] hits = Physics.OverlapSphere(rayHit.point, splashDamageRange);

                foreach(Collider hit in hits)
                {
                    if (!hit.GetComponent<HealthScript>())
                    {
                        return;
                    }

                    float totalDamage;

                    if(decreasingDamageByRange)
                    {
                        float distance = Vector3.Distance(rayHit.point, hit.transform.position);
                        float distanceInPercentages = distance / splashDamageRange * 100;
                        totalDamage = damage / 100 * distanceInPercentages;
                    }
                    else
                    {
                        totalDamage = damage;
                    }

                    hit.GetComponent<HealthScript>().Health((int)totalDamage);
                }
            }
            else
            {
                if (!rayHit.transform.gameObject.GetComponent<HealthScript>())
                {
                    return;
                }

                float totalDamage;

                if (decreasingDamageByRange)
                {
                    float distance = Vector3.Distance(endOfBarrel.position, rayHit.point);
                    float distanceInPercentages = distance / range * 100;
                    totalDamage = damage / 100 * distanceInPercentages;
                }
                else
                {
                    totalDamage = damage;
                }

                rayHit.transform.gameObject.GetComponent<HealthScript>().Health((int)totalDamage);
            }
        }
    }

    #endregion
}
