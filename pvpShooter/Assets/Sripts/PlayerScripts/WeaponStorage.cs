using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStorage : MonoBehaviour
{
    [Header("Conditions")]
    public string primaryWeaponTag;
    public string secondaryWeaponTag;
    public string meleeWeaponTag;

    [Header("Refrences")]
    public GameObject primaryWeapon;
    public GameObject secondaryWeapon;
    public GameObject meleeWeapon;

    public void Update()
    {
        ChangesWeapons();
    }

    public void ChangesWeapons()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == primaryWeaponTag && primaryWeapon == null)
        {
            primaryWeapon = collision.gameObject;
        }
        if (collision.gameObject.tag == secondaryWeaponTag && secondaryWeapon == null)
        {
            secondaryWeapon = collision.gameObject;
        }
        if (collision.gameObject.tag == meleeWeaponTag && meleeWeapon == null)
        {
            meleeWeapon = collision.gameObject;
        }
    }
}
