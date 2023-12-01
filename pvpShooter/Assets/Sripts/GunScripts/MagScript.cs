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

    Debugger debug;
    Rigidbody rb;

    #endregion

    #region start

    public void Start()
    {
        debug = GameObject.Find("DebugTool").GetComponent<Debugger>();
        rb = GetComponent<Rigidbody>();
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
        if (collidesWithGun)
        {
            debug.VrPrint("lets go");

            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.SetParent(gun.transform);

            gun.GetComponentInParent<GunScript>().mag = gameObject.GetComponent<MagScript>();

            debug.VrPrint(transform.parent.name);
        }
        else
        {
            transform.parent = null;
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    public void PickupMag(SelectEnterEventArgs arg)
    {
        //if (transform.parent != null)
        //{
        //    rb.constraints = RigidbodyConstraints.None;
        //    transform.parent = null;

        //    gun.GetComponentInParent<GunScript>().mag = null;
        //}

        if (rb.constraints == RigidbodyConstraints.FreezeAll)
        {
            rb.constraints = RigidbodyConstraints.None;
            gun.GetComponentInParent<GunScript>().mag = null;
        }
    }

    #endregion
}
