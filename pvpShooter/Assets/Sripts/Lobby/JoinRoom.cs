using UnityEngine;
using Photon.Pun;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public string playerPrefabName;
    public Transform spawnPlace;

    public void Awake()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        InstantiatePlayer();
    }

    public void InstantiatePlayer()
    {
        PhotonNetwork.Instantiate(playerPrefabName, spawnPlace.position, new Quaternion(0, 0, 0, 0));
    }
}
