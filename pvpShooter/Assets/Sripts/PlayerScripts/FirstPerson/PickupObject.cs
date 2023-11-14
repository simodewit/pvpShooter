using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public PhotonView view;

    public GameObject primaryWeapon;
    public GameObject secondaryWeapon;
    public GameObject meleeWeapon;

    public Transform primaryWeaponPlace;
    public Transform secondaryWeaponPlace;
    public Transform meleeWeaponPlace;

    GunScript gunScript;
    GameObject collider;

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<GunScript>())
        {
            return;
        }

        collider = other.gameObject;

        //print("rpc's");

        //view.RPC("PickUp", RpcTarget.All);
        PickUp();
    }

    [PunRPC]
    public void PickUp()
    {
        //print("recieved rpc");

        //if (!view.IsMine)
        //    return;

        //print("is my code");

        gunScript = collider.gameObject.GetComponent<GunScript>();

        if(gunScript.weaponType == 1)
        {
            if (primaryWeapon != null)
                return;

            primaryWeapon = collider;
            collider.transform.SetParent(primaryWeaponPlace);
            collider.transform.localPosition = Vector3.zero;
            gunScript.enabled = true;
        }
        if (gunScript.weaponType == 2)
        {
            if (secondaryWeapon != null)
                return;

            secondaryWeapon = collider;
            collider.transform.SetParent(secondaryWeaponPlace);
            collider.transform.localPosition = Vector3.zero;
            gunScript.enabled = true;
        }
        if (gunScript.weaponType == 3)
        {
            if (meleeWeapon != null)
                return;

            meleeWeapon = collider;
            collider.transform.SetParent(meleeWeaponPlace);
            collider.transform.localPosition = Vector3.zero;
            gunScript.enabled = true;
        }
    }
}
