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

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void OnTriggerEnter(Collider other)
    {
        print("triggers");

        if (!view.IsMine)
            return;

        if (!other.gameObject.GetComponent<GunScript>())
            return;

        view.RPC("PickUp", RpcTarget.All, other);
    }

    [PunRPC]
    public void PickUp(GameObject collider)
    {
        gunScript = collider.gameObject.GetComponent<GunScript>();

        if(gunScript.weaponType == 1)
        {
            if (primaryWeapon == null)
                return;

            primaryWeapon = collider;
            collider.transform.SetParent(primaryWeaponPlace);
            collider.transform.position = Vector3.zero;
            gunScript.enabled = true;
            collider.GetComponent<Collider>().isTrigger = false;
        }
        if (gunScript.weaponType == 2)
        {
            if (secondaryWeapon == null)
                return;

            primaryWeapon = collider;
            collider.transform.SetParent(primaryWeaponPlace);
            collider.transform.position = Vector3.zero;
            gunScript.enabled = true;
            collider.GetComponent<Collider>().isTrigger = false;
        }
        if (gunScript.weaponType == 3)
        {
            if (meleeWeapon == null)
                return;

            primaryWeapon = collider;
            collider.transform.SetParent(primaryWeaponPlace);
            collider.transform.position = Vector3.zero;
            gunScript.enabled = true;
            collider.GetComponent<Collider>().isTrigger = false;
        }
    }
}
