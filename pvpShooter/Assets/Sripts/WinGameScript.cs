using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameScript : MonoBehaviour
{
    public int numbKills, numbHeadshot;
    public SpawnEnemy enemySpawner;
    public GameObject[] gameScreen;

    private bool sendToMainMenu = false;

    public void OnKill()
    {
        if (numbKills == enemySpawner.maxSpawns - 10)
        {
            //10 kills remaining
        }
        if (numbKills == enemySpawner.maxSpawns - 5)
        {
            //5 kills remaining
        }
        if (numbKills == enemySpawner.maxSpawns)
        {
            for (int i = 0; i < gameScreen.Length; i++)
            {
                gameScreen[i].GetComponent<JumbotronScreen>().isWon = true;
                gameScreen[i].GetComponent<JumbotronScreen>().youWonPanel.SetActive(true);
            }
            if(sendToMainMenu == false)
            {
                Invoke("ReturnToMainMenu", 20);
                sendToMainMenu = true;
            }
            
        }
        for (int i = 0; i < gameScreen.Length; i++)
        {
            gameScreen[i].GetComponent<JumbotronScreen>().killCount.text = numbKills.ToString();
            gameScreen[i].GetComponent<JumbotronScreen>().headshotCount.text = numbHeadshot.ToString();
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
