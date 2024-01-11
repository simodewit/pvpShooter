using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region variables

    [Header("name of scene to load")]
    public string sceneName;

    [Header("Panels")]
    public GameObject splashScreenPanel;
    public GameObject mainMenuPanel;

    //private variables
    bool firstInputInSplashScreen;

    #endregion

    #region update

    public void Update()
    {
        SplashScreenCode();
    }

    #endregion

    #region code

    public void SplashScreenCode()
    {
        if(Input.anyKey && !firstInputInSplashScreen)
        {
            firstInputInSplashScreen = true;
            splashScreenPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    #endregion
}
