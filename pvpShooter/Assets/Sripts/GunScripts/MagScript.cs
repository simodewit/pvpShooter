using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagScript : MonoBehaviour
{
    #region variables

    [Header("refrences")]
    public int bullets;
    public LayerMask layer;
    public string tagName;

    //privates
    bool collidesWithGun;
    GameObject gun;
    Rigidbody rb;

    Debugger debug;

    #endregion

    #region start

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        debug = GameObject.Find("DebugTool").GetComponent<Debugger>();
    }

    #endregion

    #region checks collision

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagName)
        {
            collidesWithGun = true;
            gun = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == tagName)
        {
            collidesWithGun = false;
            gun = null;
        }
    }

    #endregion

    #region pickup and drop

    public void LetGoOfMag(SelectExitEventArgs arg)
    {
        debug.ErrorFinder(Check);
    }

    public void Check()
    {
        if (collidesWithGun && gun.GetComponentInParent<GunScript>().mag == null)
        {
            debug.Print("1 if");

            rb.constraints = RigidbodyConstraints.FreezePosition;
            transform.SetParent(gun.transform);

            transform.localRotation = Quaternion.identity;
            transform.localPosition = Vector3.zero;

            gun.GetComponentInParent<GunScript>().mag = gameObject.GetComponent<MagScript>();
        }
        else
        {
            debug.Print("1 else");

            rb.constraints = RigidbodyConstraints.None;
            transform.parent = null;
        }
    }

    public void PickupMag(SelectEnterEventArgs arg)
    {
        debug.ErrorFinder(Check2);
    }

    public void Check2()
    {
        debug.Print("2");

        rb.constraints = RigidbodyConstraints.None;
        transform.parent = null;
        gun.GetComponentInParent<GunScript>().mag = null;
    }

    #endregion
}
