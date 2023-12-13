using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionSwitch : MonoBehaviour
{
    [Header("refrences")]
    public XRDirectInteractor grabInteractor;
    public GameObject rayInteractor;
    public GameObject leftHand;
    public GameObject rightHand;
    public float range;

    RaycastHit leftHit;
    RaycastHit rightHit;

    public void Update()
    {
        Scan();
    }

    public void Scan()
    {
        if (Physics.Raycast(leftHand.transform.position, leftHand.transform.forward, out leftHit, range))
        {
            if (leftHit.transform.root.GetComponent<Canvas>())
            {
                grabInteractor.
                rayInteractor.gameObject.SetActive(true);
            }
        }
        else if (Physics.Raycast(rightHand.transform.position, rightHand.transform.forward, out rightHit, range))
        {

        }
    }
}
