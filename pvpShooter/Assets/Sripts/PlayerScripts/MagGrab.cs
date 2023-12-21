using Photon.Pun;
using UnityEngine;

public class MagGrab : MonoBehaviourPunCallbacks
{
    public string leftHandTag;
    public string rightHandTag;

    public string magName;

    bool handCollides;
    bool hasMagSpawned;
    GameObject mag;

    public void Start()
    {
        photonView.RPC("SpawnMag", RpcTarget.All);
    }

    public void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (!handCollides && !hasMagSpawned)
        {
            hasMagSpawned = true;
            photonView.RPC("SpawnMag", RpcTarget.All);
        }
    }

    public void SpawnMag()
    {
        mag = PhotonNetwork.Instantiate(magName, transform.position, Quaternion.identity);
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
