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

    [Header("bullet info")]
    public string bulletName;
    public float bulletSpeed;

    //private variables
    Debugger debugger;
    PhotonView view;

    #endregion

    #region start and update

    public void Start()
    {
        Refrences();
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
        debugger.VrPrint("shoot");

        GameObject bullet = PhotonNetwork.Instantiate(bulletName, endOfBarrel.localPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Force);

        debugger.VrPrint(bullet.name);
    }

    #endregion
}
