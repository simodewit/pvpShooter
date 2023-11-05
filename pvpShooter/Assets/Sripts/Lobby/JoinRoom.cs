using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public Transform spawnPlace;
    public PhotonView view;

    public void Start()
    {
        view = GetComponent<PhotonView>();

        if(!view.IsMine)
            return;

        view.RPC("InstantiatePlayer", RpcTarget.All);
    }

    [PunRPC]
    public void InstantiatePlayer()
    {
        PhotonNetwork.Instantiate("Player", spawnPlace.position, new Quaternion(0, 0, 0, 0));
    }
}
