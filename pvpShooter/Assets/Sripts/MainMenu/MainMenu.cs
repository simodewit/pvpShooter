using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviourPunCallbacks
{
    [Header("Panels")]
    public GameObject splashScreenPanel;
    public GameObject mainMenuPanel;
    public GameObject createOrJoinRoomPanel;

    [Header("UI elements")]
    public TextMeshProUGUI inputForJoiningRoom;
    public TextMeshProUGUI inputForCreatingRoom;

    bool onConnectionStart;
    bool firstInputInSplashScreen;

    public void Update()
    {
        SplashScreenCode();
    }

    public void SplashScreenCode()
    {
        if(Input.anyKey && !firstInputInSplashScreen)
        {
            PhotonNetwork.GameVersion = ("0.0.1");
            PhotonNetwork.ConnectUsingSettings();
            firstInputInSplashScreen = true;
        }

        if (onConnectionStart)
        {
            splashScreenPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            onConnectionStart = false;
        }
    }

    #region Button Functions

    public void OnClickPlay()
    {
        mainMenuPanel.SetActive(false);
        createOrJoinRoomPanel.SetActive(true);
    }

    public void OnClickJoinRoom()
    {
        if (inputForJoiningRoom.text == "")
            return;

        PhotonNetwork.JoinRoom(inputForJoiningRoom.text);
    }

    public void OnClickCreateRoom()
    {
        if (inputForCreatingRoom.text == "")
            return;

        PhotonNetwork.CreateRoom(inputForCreatingRoom.text);
    }

    #endregion

    #region PUN code

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SimonsTestScene");
    }

    public override void OnConnectedToMaster()
    {
        onConnectionStart = true;
    }

    #endregion
}