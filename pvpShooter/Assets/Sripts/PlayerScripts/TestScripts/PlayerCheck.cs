using Photon.Pun;
using UnityEngine;

public class PlayerCheck : MonoBehaviourPunCallbacks
{
    public GameObject XrRig;

    public void Start()
    {
        Debug.Log(photonView.IsMine + ", " + gameObject.name);
    }

    public void Update()
    {
        if (!photonView.IsMine)
        {
            XrRig.SetActive(false);
        }
        else
        {
            XrRig.SetActive(true);
        }
    }
}
