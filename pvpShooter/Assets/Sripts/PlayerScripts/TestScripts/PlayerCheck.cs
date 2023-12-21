using Photon.Pun;
using UnityEngine;

public class PlayerCheck : MonoBehaviourPunCallbacks
{
    public GameObject cam;
    public GameObject leftController;
    public GameObject rightController;

    public void Start()
    {
        if (!photonView.IsMine)
        {
            cam.SetActive(false);
            leftController.SetActive(false);
            rightController.SetActive(false);
        }
    }
}
