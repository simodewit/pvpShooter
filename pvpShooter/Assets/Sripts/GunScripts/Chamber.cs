using UnityEngine;

public class Chamber : MonoBehaviour
{
    #region variables

    [Header("all info")]
    public float speed;
    public float maxDistance;
    public string leftHandTag;
    public string rightHandTag;

    //privates
    XRIDefaultInputActions action;
    bool leftActivated;
    bool rightActivated;
    bool hasHand;

    Vector3 startPos;

    Collider leftHand;
    Collider rightHand;

    #endregion

    #region start and update

    public void Start()
    {
        startPos = transform.localPosition;

        action = new XRIDefaultInputActions();
        action.Enable();
    }

    public void Update()
    {
        Input();
        Pickup();
    }

    #endregion

    #region input

    public void OnEnable()
    {
        action = new XRIDefaultInputActions();
        action.Enable();
    }

    public void OnDisable()
    {
        action.Disable();
    }

    public void Input()
    {
        if (action.XRILeftHandInteraction.Select.IsPressed())
        {
            leftActivated = true;
        }
        else if (action.XRIRightHandInteraction.Select.IsPressed())
        {
            rightActivated = true;
        }
        else
        {
            leftActivated = false;
            rightActivated = false;
        }
    }

    #endregion

    #region collision

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == leftHandTag)
        {
            leftHand = other;
            hasHand = true;
        }
        if (other.tag == rightHandTag)
        {
            leftHand = other;
            hasHand = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        leftHand = null;
        rightHand = null;
        hasHand = false;
    }

    #endregion

    #region pickup

    public void Pickup()
    {
        if(!hasHand)
        {
            return;
        }

        Vector3 endPos = new Vector3();

        if (leftHand != null && leftActivated)
        {
             leftHand.transform.InverseTransformPoint(endPos);
        }
        else if(rightHand != null && rightActivated)
        {
            rightHand.transform.InverseTransformPoint(endPos);
        }

        endPos.x = startPos.x;
        endPos.y = startPos.y;

        transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, speed);
    }

    #endregion
}
