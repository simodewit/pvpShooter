using Photon.Pun;
using UnityEngine;

public class SpawnPlaces : MonoBehaviour
{
    #region variables

    [Header("name of the player prefab")]
    public string playerPrefabName;

    [Header("places for the team spawns")]
    public Transform spawnPlaceTeamA;
    public Transform spawnPlaceTeamB;

    //privates
    bool teamA;
    bool hasSpawned;

    #endregion

    #region start

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

    #endregion

    #region you died code

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

    #endregion
}
