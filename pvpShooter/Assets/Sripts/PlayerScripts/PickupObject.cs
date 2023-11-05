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
        if (!view.IsMine)
        {
            return;
        }

        if (!other.gameObject.GetComponent<GunScript>())
        {
            return;
        }

        collider = other.gameObject;
        PickUp();
    }

    [PunRPC]
    public void PickUp()
    {
        if (!view.IsMine)
            return;

        gunScript = collider.gameObject.GetComponent<GunScript>();

        if(gunScript.weaponType == 1)
        {
            if (primaryWeapon != null)
                return;

            view.RPC("PrimaryWeaponPlace", RpcTarget.All);
        }
        if (gunScript.weaponType == 2)
        {
            if (secondaryWeapon != null)
                return;

            view.RPC("SecondaryWeaponPlace", RpcTarget.All);
        }
        if (gunScript.weaponType == 3)
        {
            if (meleeWeapon != null)
                return;

            view.RPC("MeleeWeaponPlace", RpcTarget.All);
        }
    }

    public void PrimaryWeaponPlace()
    {
        primaryWeapon = collider;
        collider.transform.SetParent(primaryWeaponPlace);
        collider.transform.localPosition = Vector3.zero;
        gunScript.enabled = true;
    }

    public void SecondaryWeaponPlace()
    {
        secondaryWeapon = collider;
        collider.transform.SetParent(secondaryWeaponPlace);
        collider.transform.localPosition = Vector3.zero;
        gunScript.enabled = true;
    }

    public void MeleeWeaponPlace()
    {
        meleeWeapon = collider;
        collider.transform.SetParent(meleeWeaponPlace);
        collider.transform.localPosition = Vector3.zero;
        gunScript.enabled = true;
    }
}
