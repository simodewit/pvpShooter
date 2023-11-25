using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviourPunCallbacks
{
    #region variables

    [Header("name of scene to load")]
    public string sceneName;

    [Header("Panels")]
    public GameObject splashScreenPanel;
    public GameObject mainMenuPanel;
    public GameObject createOrJoinRoomPanel;

    [Header("UI elements")]
    public TextMeshProUGUI inputForJoiningRoom;
    public TextMeshProUGUI inputForCreatingRoom;

    [Header("keyboard")]
    public GameObject keyboard;

    [Header("debugging")]
    public Debugger debugger;

    //private variables
    bool onConnectionStart;
    bool firstInputInSplashScreen;
    bool temp;

    #endregion

    #region update

    public void Update()
    {
        SplashScreenCode();
    }

    #endregion

    #region splash screen code

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

    #endregion

    #region Button Functions

    public void OnClickPlay()
    {
        mainMenuPanel.SetActive(false);
        createOrJoinRoomPanel.SetActive(true);
    }

    public void OnClickJoinRoom()
    {
        if (inputForJoiningRoom.text == "")
        {
            inputForCreatingRoom.text = "1";
        }

        PhotonNetwork.JoinRoom(inputForJoiningRoom.text);
    }

    public void OnClickCreateRoom()
    {
        if (inputForCreatingRoom.text == "")
        {
            inputForCreatingRoom.text = "1";
        }

        if (temp)
        {
            return;
        }

        temp = true;
        debugger.VrPrint(inputForCreatingRoom.text);
        PhotonNetwork.CreateRoom(inputForCreatingRoom.text);
    }

    #endregion

    #region PUN code

    public override void OnJoinedRoom()
    {
        debugger.VrPrint(sceneName);
        PhotonNetwork.LoadLevel(sceneName);
        debugger.VrPrint("loaded next scene");
    }

    public override void OnConnectedToMaster()
    {
        debugger.VrPrint("connected to servers");
        onConnectionStart = true;
    }

    #endregion
}
