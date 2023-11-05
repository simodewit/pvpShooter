using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public Transform spawnPlace;
    public PhotonView view;

    bool hasSpawned;

    public void Start()
    {
        view = GetComponent<PhotonView>();

        if(hasSpawned)
            return;

        hasSpawned = true;
        InstantiatePlayer();
    }

    public void InstantiatePlayer()
    {
        PhotonNetwork.Instantiate("Player", spawnPlace.position, new Quaternion(0, 0, 0, 0));
    }
}
