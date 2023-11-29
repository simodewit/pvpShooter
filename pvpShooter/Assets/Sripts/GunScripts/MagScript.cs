using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagScript : MonoBehaviour
{
    #region variables

    [Header("refrences")]
    public int bullets;
    public LayerMask layer;

    [Header("snapOnCode")]
    public float seekDistance;
    public float snapDistance;
    public string attachPointName;

    Debugger debug;

    //privates
    Rigidbody rb;
    GunScript gun;
    Collider col;

    #endregion

    #region start

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        debug = GameObject.Find("DebugTool").GetComponent<Debugger>();
    }

    #endregion

    #region pickup code

    public void PickupMag(SelectEnterEventArgs arg)
    {
        if (gun != null)
        {
            gun.mag = null;
            gun = null;
        }

        transform.SetParent(null);
        rb.useGravity = true;
    }

    #endregion

    #region drop mag code

    public void LetGoOfMag(SelectExitEventArgs arg)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, seekDistance, layer);

        foreach (var collider in colliders)
        {
            if (collider.GetComponent<GunScript>() != null)
            {
                float distance = Vector3.Distance(transform.position, collider.gameObject.GetNamedChild(attachPointName).transform.position);

                if (distance < snapDistance && collider.GetComponent<GunScript>().mag == null)
                {
                    gun = collider.GetComponent<GunScript>();
                    gun.mag = gameObject.GetComponent<MagScript>();
                    transform.SetParent(gun.gameObject.GetNamedChild(attachPointName).transform);
                    transform.localPosition = Vector3.zero;
                    rb.useGravity = false;
                }
            }
        }
    }

    #endregion
}
