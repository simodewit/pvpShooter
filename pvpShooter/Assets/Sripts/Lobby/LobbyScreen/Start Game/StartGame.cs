using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int sceneIndex;

    public void OnClick()
    {
        PhotonNetwork.LoadLevel(sceneIndex);
    }
}
