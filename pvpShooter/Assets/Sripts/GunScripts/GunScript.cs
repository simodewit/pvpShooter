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
    public float shootInterval;

    [Header("SplashDamage")]
    public bool splashDamage;
    public float splashDamageRange;

    [Header("refrences")]
    public Transform endOfBarrel;

    [Header("bullet info")]
    public string bulletName;
    public float bulletSpeed;

    //private variables
    Debugger debugger;
    PhotonView view;

    bool hasShot;
    bool canShoot;

    float timer;

    #endregion

    #region start and update

    public void Start()
    {
        Refrences();
    }

    public void Update()
    {
        Automatic();
    }

    #endregion

    #region refrences

    public void Refrences()
    {
        view = GetComponent<PhotonView>();
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        debugger = GameObject.Find("DebugTool").GetComponent<Debugger>();
        grabbable.activated.AddListener(Shoot);
    }

    #endregion

    #region shoot code

    [PunRPC]
    public void Shoot(ActivateEventArgs arg)
    {
        if(automaticGun)
        {
            if(canShoot)
            {
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }
        }
        else
        {
            if (hasShot)
            {
                hasShot = false;
            }
            else
            {
                Bullet();
                hasShot = true;
            }
        }
    }
    
    public void Automatic()
    {
        debugger.VrPrint(timer.ToString());
        if (canShoot)
        {
            debugger.VrPrint("auto");
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                debugger.VrPrint("shoot");
                timer = shootInterval;
                Bullet();
            }
        }
        else
        {
            timer = 0;
        }
    }

    public void Bullet()
    {
        GameObject bullet = PhotonNetwork.Instantiate(bulletName, endOfBarrel.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }

    #endregion
}
