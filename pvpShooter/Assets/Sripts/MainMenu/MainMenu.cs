using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
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
            return;
        }
    }

    public void OnClickCreateRoom()
    {
        if (CreateRoomInput.text == "")
        {
            return;
        }

        if (temp)
        {
            return;
        }

        temp = true;
    }

    #endregion
}
