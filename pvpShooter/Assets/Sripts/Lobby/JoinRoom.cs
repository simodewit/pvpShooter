using UnityEngine;
using Photon.Pun;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public GameObject team1, team2;
    public string playerPrefabName, playerButtonName;
    public Transform spawnPlace;
    public GameObject spawnedButton;
    bool hasSpawned;

    public void Awake()
    {
        // The instantiate first happend in the if statment pohotonview.ismine but it didnt work so i changed it
        // Simon needs to look at this
        PhotonNetwork.Instantiate(playerPrefabName, spawnPlace.position, new Quaternion(0, 0, 0, 0));
        if (photonView.IsMine)
        {
            
            hasSpawned = true;
        }

        if (team1 != null)
        {
            photonView.RPC("ChangeButtons", RpcTarget.All);
        }
    }

    [PunRPC]
    public void ChangeButtons()
    {
        if (PhotonNetwork.PlayerList.Length % 2 == 0)
        {
            spawnedButton = PhotonNetwork.Instantiate(playerButtonName, team1.transform.position, new Quaternion(0, 0, 0, 0));
            spawnedButton.transform.SetParent(team1.transform, true);
        }
        else
        {
            spawnedButton = PhotonNetwork.Instantiate(playerButtonName, team2.transform.position, new Quaternion(0, 0, 0, 0));
            spawnedButton.transform.SetParent(team2.transform, true);
        }

        spawnedButton.transform.rotation = new Quaternion(0, 0, 0, 0);
        spawnedButton.transform.localScale = Vector3.one;
        spawnedButton = null;
    }
}
