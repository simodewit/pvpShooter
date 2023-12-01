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
            gun = other.gameObject;
        }
    }

    #endregion

    #region pickup and drop

    public void PickupMag(SelectEnterEventArgs arg)
    {
        if (transform.parent != null)
        {
            transform.parent = null;
        }
    }

    public void LetGoOfMag(SelectExitEventArgs arg)
    {
        if (collidesWithGun)
        {
            transform.SetParent(gun.transform);
        }
    }

    #endregion
}
