using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Chamber : MonoBehaviour
{
    [Header("all info")]
    public float speed;
    public float maxDistance;

    //privates
    XRIDefaultInputActions action;
    bool hasActivated;
    Vector3 startPos;
    Collider hand;

    Debugger debug;

    public void Start()
    {
        debug = GameObject.Find("DebugTool").GetComponent<Debugger>();

        startPos = transform.localPosition;
        action = new XRIDefaultInputActions();
    }

    public void Update()
    {
        if (action.XRILeftHandInteraction.Activate.IsPressed())
        {
            Pickup(hand);
        }
        else
        {
            hasActivated = false;
        }
    }

    public void Pickup(Collider other)
    {
        if (other == null)
        {
            return;
        }
        if(other.GetComponent<XRGrabInteractable>() == null)
        {
            return;
        }

        debug.Print("Gets input and collision");

        Vector3 endPos = new Vector3();

        if (hasActivated)
        {
            endPos.x = startPos.x;
            endPos.y = startPos.y;
            endPos.z = other.transform.position.z;
        }
        else
        {
            endPos = startPos;
        }

        if (endPos.z > startPos.z + maxDistance)
        {
            endPos.z = startPos.z + maxDistance;
        }
        else if (endPos.z < startPos.z)
        {
            endPos.z = startPos.z;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        hand = other;
    }

    public void OnTriggerExit(Collider other)
    {
        hand = null;
    }
}
