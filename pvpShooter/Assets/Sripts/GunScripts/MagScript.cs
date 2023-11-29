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
        debug.VrPrint("picks up mag");

        gun.mag = null;
        transform.parent = null;
        gun = null;
        rb.useGravity = true;
        col.enabled = true;
    }

    #endregion

    #region drop mag code

    public void LetGoOfMag(SelectExitEventArgs arg)
    {
        debug.VrPrint("drops mag");

        Collider[] colliders = Physics.OverlapSphere(transform.position, seekDistance, layer);

        foreach (var collider in colliders)
        {
            if (collider.GetComponent<GunScript>() != null)
            {
                float distance = Vector3.Distance(transform.position, collider.gameObject.GetNamedChild(attachPointName).transform.position);

                if (distance < snapDistance && collider.GetComponent<GunScript>().mag == null)
                {
                    debug.VrPrint("attaches mag");

                    collider.GetComponent<GunScript>().mag = gameObject.GetComponent<MagScript>();
                    gun = collider.GetComponent<GunScript>();
                    transform.parent = collider.gameObject.GetNamedChild(attachPointName).transform;
                    rb.useGravity = false;
                    col.enabled = false;
                }
            }
        }
    }

    #endregion
}
