using UnityEngine;

public class Chamber : MonoBehaviour
{
    #region variables

    [Header("all info")]
    public float speed;
    public float maxDistance;
    public float distanceForLoad;

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
        if (action.XRILeftHandInteraction.Activate.IsPressed())
        {
            leftActivated = true;
        }
        else if(leftActivated)
        {
            leftActivated = false;
            leftHand = null;
            rightHand = null;
        }

        if (action.XRIRightHandInteraction.Activate.IsPressed())
        {
            rightActivated = true;
        }
        else if(rightActivated)
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
            transform.position = Vector3.Slerp(worldPos, leftHand.transform.position, speed);
            endPos.z = transform.localPosition.z;
        }
        else if(rightHand != null && rightActivated)
        {
            transform.position = Vector3.Slerp(worldPos, rightHand.transform.position, speed);
            endPos.z = transform.localPosition.z;
        }
        else
        {
            endPos.z = startPos.z;
        }

        endPos.x = startPos.x;
        endPos.y = startPos.y;
        
        if (endPos.z < -maxDistance)
        {
            endPos.z = -maxDistance;
        }
        if (endPos.z > startPos.z)
        {
            endPos.z = startPos.z;
        }

        if (gun.mag != null && gun.mag.bullets != 0 && endPos.z < -distanceForLoad && !gun.isChambered)
        {
            gun.isChambered = true;
            gun.mag.bullets -= 1;
        }

        transform.localPosition = endPos;
        transform.localRotation = Quaternion.identity;
    }

    #endregion
}
