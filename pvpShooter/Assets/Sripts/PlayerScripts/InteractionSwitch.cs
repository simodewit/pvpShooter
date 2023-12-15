using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionSwitch : MonoBehaviour
{
    [Header("refrences")]
    public XRDirectInteractor grabInteractor;
    public GameObject rayInteractor;
    public float range;
    public LayerMask layer;

    RaycastHit hit;
    Debugger debug;

    public void Start()
    {
        debug = GameObject.Find("DebugTool").GetComponent<Debugger>();
    }

    public void Update()
    {
        Scan();
    }

    public void Scan()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, layer))
        {
            debug.Print(hit.transform.name);

            if (hit.transform.root.GetComponent<Canvas>())
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
}
