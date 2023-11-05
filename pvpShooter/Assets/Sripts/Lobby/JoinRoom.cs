using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public Transform spawnPlace;
    public PhotonView view;

    int players;

    public void Start()
    {
        HostJoinCode();
    }

    public void Update()
    {
        if(players != PhotonNetwork.CurrentRoom.PlayerCount)
        {
            PhotonNetwork.Instantiate("Player", spawnPlace.position, new Quaternion(0, 0, 0, 0));
            players = PhotonNetwork.CurrentRoom.PlayerCount;
        }
    }

    public void HostJoinCode()
    {
        view = GetComponent<PhotonView>();

        if (!view.IsMine)
            return;

        view.RPC("InstantiatePlayer", RpcTarget.All);
        players = PhotonNetwork.CurrentRoom.PlayerCount;
    }

    [PunRPC]
    public void InstantiatePlayer()
    {
        PhotonNetwork.Instantiate("Player", spawnPlace.position, new Quaternion(0, 0, 0, 0));
    }
}
