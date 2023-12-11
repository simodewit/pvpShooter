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

    Vector3 startPos;
    Vector3 worldPos;

    Collider leftHand;
    Collider rightHand;
    GunScript gun;

    Debugger debug;

    #endregion

    #region start and update

    public void Start()
    {
        debug = GameObject.Find("DebugTool").GetComponent<Debugger>();

        gun = transform.parent.transform.parent.GetComponent<GunScript>();
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
        else
        {
            leftActivated = false;
            leftHand = null;
            rightHand = null;
        }

        if (action.XRIRightHandInteraction.Select.IsPressed())
        {
            rightActivated = true;
        }
        else
        {
            rightActivated = false;
            leftHand = null;
            rightHand = null;
        }
    }

    #endregion

    #region collision

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == leftHandTag)
        {
            leftHand = other;
        }
        if (other.tag == rightHandTag)
        {
            rightHand = other;
        }
    }

    #endregion

    #region pickup

    public void Pickup()
    {
        worldPos = transform.parent.transform.position;
        Vector3 endPos = new Vector3();

        if (leftHand != null && leftActivated)
        {
            endPos.z = -Vector3.Distance(worldPos, leftHand.transform.position);
        }
        else if(rightHand != null && rightActivated)
        {
            endPos.z = -Vector3.Distance(worldPos, rightHand.transform.position);
        }
        else
        {
            endPos.z = startPos.z;
        }

        endPos.x = startPos.x;
        endPos.y = startPos.y;

        if (endPos.z < -maxDistance)
        {
            endPos.z = maxDistance;
        }
        if (endPos.z > startPos.z)
        {
            endPos.z = -maxDistance;

            if (gun.mag != null && gun.mag.bullets != 0)
            {
                gun.isChambered = true;
            }
        }

        transform.localPosition = endPos;
        transform.localRotation = Quaternion.identity;
    }

    #endregion
}
