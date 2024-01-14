using UnityEngine;

public class MagGrab : MonoBehaviour
{
    public string leftHandTag;
    public string rightHandTag;

    public GameObject magPrefab;

    bool handCollides;
    bool hasMagSpawned;
    GameObject mag;

    public void Start()
    {
        SpawnMag();
    }

    public void Update()
    {
        if (!handCollides && !hasMagSpawned)
        {
            hasMagSpawned = true;
            SpawnMag();
        }
    }

    public void SpawnMag()
    {
        mag = Instantiate(magPrefab, transform.position, Quaternion.identity);
        mag.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == leftHandTag || other.tag == rightHandTag)
        {
            handCollides = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == leftHandTag || other.tag == rightHandTag)
        {
            handCollides = false;
        }
    }
}
