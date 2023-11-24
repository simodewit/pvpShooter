using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlaces : MonoBehaviour
{
    [Header("name of the player prefab")]
    public string playerPrefabName;

    [Header("places for the team spawns")]
    public Transform spawnPlaceTeamA;
    public Transform spawnPlaceTeamB;

    bool teamA;
    bool hasSpawned;

    public void Start()
    {
        if(hasSpawned)
        {
            return;
        }

        if(teamA)
        {
            PhotonNetwork.Instantiate(playerPrefabName, spawnPlaceTeamA.transform.position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(playerPrefabName, spawnPlaceTeamB.transform.position, Quaternion.identity);
        }
    }

    public void Died(Transform playerTransform)
    {
        if (teamA)
        {
            playerTransform.position = spawnPlaceTeamA.position;
        }
        else
        {
            playerTransform.position = spawnPlaceTeamA.position;
        }
    }
}
