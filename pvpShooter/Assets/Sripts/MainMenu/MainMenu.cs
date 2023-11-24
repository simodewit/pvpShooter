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
    public Debugger Debugger;

    //private variables
    bool onConnectionStart;
    bool firstInputInSplashScreen;
    bool selectedJoin;
    bool selectedCreate;

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
        //if (inputForJoiningRoom.text == "")
        //{
        //    return;
        //}

        PhotonNetwork.JoinRoom(inputForJoiningRoom.text);
    }

    public void OnClickCreateRoom()
    {
        //if (inputForCreatingRoom.text == "")
        //{
        //    return;
        //}

        PhotonNetwork.CreateRoom(inputForCreatingRoom.text);
    }

    #endregion

    #region Keyboard

    public void DisableKeyboardJoin()
    {
        keyboard.SetActive(false);
        selectedJoin = false;
    }

    public void DisableKeyboardCreate()
    {
        keyboard.SetActive(false);
        selectedCreate = false;
    }

    public void EnableKeyboardJoin()
    {
        keyboard.SetActive(true);
        selectedJoin = true;
    }

    public void EnableKeyboardCreate()
    {
        keyboard.SetActive(true);
        selectedJoin = true;
    }

    public void Keyboard1()
    {
        if (selectedCreate)
        {
            inputForCreatingRoom.text += 1;
        }
        if (selectedJoin)
        {
            inputForJoiningRoom.text += 1;
        }
    }

    #endregion

    #region PUN code

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

    public override void OnConnectedToMaster()
    {
        onConnectionStart = true;
    }

    #endregion
}
