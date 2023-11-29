using UnityEngine;
using Photon.Pun;
using TMPro;

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
    public TextMeshProUGUI JoinRoomInput;
    public TextMeshProUGUI CreateRoomInput;
    public GameObject keyboard;

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
        if (JoinRoomInput.text == "")
        {
            CreateRoomInput.text = "1";
            //normaly this should be a return but for testing purposes this is now giving a name
        }

        PhotonNetwork.JoinRoom(JoinRoomInput.text);
    }

    public void OnClickCreateRoom()
    {
        if (CreateRoomInput.text == "")
        {
            CreateRoomInput.text = "1";
            //normaly this should be a return but for testing purposes this is now giving a name
        }

        if (temp)
        {
            return;
        }

        temp = true;
        PhotonNetwork.CreateRoom(CreateRoomInput.text);
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
