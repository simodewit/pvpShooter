using Photon.Pun;
using UnityEngine;

public class PlayerCheck : MonoBehaviourPunCallbacks
{
    public GameObject XrRig;

    public void Start()
    {
        if (!photonView.IsMine)
        {
            XrRig.SetActive(false);
        }
    }
}
