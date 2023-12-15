using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionSwitch : MonoBehaviour
{
    [Header("refrences")]
    public XRDirectInteractor grabInteractor;
    public GameObject rayInteractor;
    public LayerMask layer;
    public string colliderTag;

    public void Start()
    {
        rayInteractor.SetActive(false);
        grabInteractor.enabled = true;
    }

    public void Update()
    {
        bool hasCollided = new bool();
        Collider[] a = Physics.OverlapSphere(transform.position, 1);

        foreach (var col in a)
        {
            if (!hasCollided && col.tag == colliderTag)
            {
                hasCollided = true;
            }
        }

        if (hasCollided)
        {
            grabInteractor.enabled = false;
            rayInteractor.SetActive(true);
        }
        else
        {
            rayInteractor.SetActive(false);
            grabInteractor.enabled = true;
        }
    }
}
