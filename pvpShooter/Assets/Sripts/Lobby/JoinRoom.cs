using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public Transform spawnPlace;

    public void Start()
    {
        PhotonNetwork.Instantiate("Player", spawnPlace.position, new Quaternion(0, 0, 0, 0));
    }
}
