using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionSwitch : MonoBehaviour
{
    [Header("refrences")]
    public XRDirectInteractor grabInteractor;
    public GameObject rayInteractor;
    public string ColliderTag;

    public void Start()
    {
        rayInteractor.SetActive(false);
        grabInteractor.enabled = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == ColliderTag)
        {
            grabInteractor.enabled = false;
            rayInteractor.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == ColliderTag)
        {
            rayInteractor.SetActive(false);
            grabInteractor.enabled = true;
        }
    }
}
