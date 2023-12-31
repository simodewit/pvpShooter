using UnityEngine;
using Photon.Pun;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public GameObject team1, team2;
    public string playerPrefabName, playerButtonName;
    public Transform spawnPlace;
    public GameObject spawnedButton;

    public void Awake()
    {
        PhotonNetwork.Instantiate(playerPrefabName, spawnPlace.position, new Quaternion(0, 0, 0, 0));

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
