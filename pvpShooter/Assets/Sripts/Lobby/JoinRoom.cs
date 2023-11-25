using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public string playerPrefabName;
    public Transform spawnPlace;
    bool hasSpawned;

    public void Awake()
    {
        if(hasSpawned)
        {
            return;
        }

        hasSpawned = true;
        InstantiatePlayer();
    }

    public void InstantiatePlayer()
    {
        PhotonNetwork.Instantiate(playerPrefabName, spawnPlace.position, new Quaternion(0, 0, 0, 0));
    }
}
