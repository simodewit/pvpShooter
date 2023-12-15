using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagScript : MonoBehaviourPunCallbacks
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

    #region start and update

    public void Start()
    {
        debug = GameObject.Find("DebugTool").GetComponent<Debugger>();
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (transform.parent != null)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
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
        if (gun != null)
        {
            if (collidesWithGun && gun.GetComponentInParent<GunScript>().mag == null)
            {
                transform.SetParent(gun.transform);

                transform.localRotation = Quaternion.identity;
                transform.localPosition = Vector3.zero;

                rb.constraints = RigidbodyConstraints.FreezeAll;

                gun.GetComponentInParent<GunScript>().mag = gameObject.GetComponent<MagScript>();

                if (gun.GetComponent<GunScript>().isChambered)
                {
                    gun.GetComponent<GunScript>().ammoScreen.text = (bullets + 1).ToString();
                }
                else
                {
                    gun.GetComponent<GunScript>().ammoScreen.text = bullets.ToString();
                }
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            transform.parent = null;

            if (gun != null)
            {
                if (gun.GetComponentInParent<GunScript>().mag != null)
                {
                    gun.GetComponentInParent<GunScript>().mag = null;
                }
            }
        }
    }

    public void PickupMag(SelectEnterEventArgs arg)
    {
        rb.constraints = RigidbodyConstraints.None;
        transform.parent = null;

        if (gun != null)
        {
            if (gun.GetComponent<GunScript>().isChambered)
            {
                gun.GetComponent<GunScript>().ammoScreen.text = "1";
            }
            else
            {
                gun.GetComponent<GunScript>().ammoScreen.text="0";
            }
            if (gun.GetComponentInParent<GunScript>().mag != null)
            {
                gun.GetComponentInParent<GunScript>().mag = null;
            }
        }
    }

    #endregion
}
