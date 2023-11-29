using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagSpawn : MonoBehaviour
{
    public string magName;

    GameObject hand;

    public void SpawnMag()
    {
        GameObject a = PhotonNetwork.Instantiate(magName, hand.transform.position, Quaternion.identity);
        a.transform.SetParent(hand.transform);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<XRDirectInteractor>() != null)
        {
            hand = other.gameObject;
        }
    }
}
