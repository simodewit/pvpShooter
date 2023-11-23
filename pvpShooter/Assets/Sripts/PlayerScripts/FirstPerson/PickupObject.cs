using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    #region variables

    public GameObject primaryWeapon;
    public GameObject secondaryWeapon;
    public GameObject meleeWeapon;

    public Transform primaryWeaponPlace;
    public Transform secondaryWeaponPlace;
    public Transform meleeWeaponPlace;

    GunScript gunScript;
    GameObject colliderOfGameobject;
    PhotonView view;

    #endregion

    #region start

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    #endregion

    #region checking colision

    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<GunScript>())
        {
            return;
        }

        colliderOfGameobject = other.gameObject;

        PickUp();
    }

    #endregion

    #region pickup code

    [PunRPC]
    public void PickUp()
    {
        gunScript = colliderOfGameobject.gameObject.GetComponent<GunScript>();

        if(gunScript.weaponType == 1)
        {
            if (primaryWeapon != null)
            {
                return;
            }

            primaryWeapon = colliderOfGameobject;
            colliderOfGameobject.transform.SetParent(primaryWeaponPlace);
            colliderOfGameobject.transform.localPosition = Vector3.zero;
            gunScript.enabled = true;
        }
        if (gunScript.weaponType == 2)
        {
            if (secondaryWeapon != null)
            {
                return;
            }

            secondaryWeapon = colliderOfGameobject;
            colliderOfGameobject.transform.SetParent(secondaryWeaponPlace);
            colliderOfGameobject.transform.localPosition = Vector3.zero;
            gunScript.enabled = true;
        }
        if (gunScript.weaponType == 3)
        {
            if (meleeWeapon != null)
            {
                return;
            }

            meleeWeapon = colliderOfGameobject;
            colliderOfGameobject.transform.SetParent(meleeWeaponPlace);
            colliderOfGameobject.transform.localPosition = Vector3.zero;
            gunScript.enabled = true;
        }
    }

    #endregion
}
