using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameScript : MonoBehaviour
{
    public int numbKills, numbHeadshot;
    public SpawnEnemy enemySpawner;
    public GameObject[] gameScreen;
    public AudioSource win, tenRemaining, five, four, three, two, one;

    private bool sendToMainMenu = false;

    public void OnKill()
    {
        if (numbKills == enemySpawner.maxSpawns - 10)
        {
            tenRemaining.Play();
        }
        if (numbKills == enemySpawner.maxSpawns - 5)
        {
            //5 kills remaining
        }
        if (numbKills == enemySpawner.maxSpawns)
        {
            for (int i = 0; i < gameScreen.Length; i++)
            {
                win.Play();
                gameScreen[i].GetComponent<JumbotronScreen>().winHeadshots.text = numbHeadshot.ToString();
                gameScreen[i].GetComponent<JumbotronScreen>().winTime.text = gameScreen[0].GetComponent<JumbotronScreen>().time.text;
                gameScreen[i].GetComponent<JumbotronScreen>().isWon = true;
                gameScreen[i].GetComponent<JumbotronScreen>().youWonPanel.SetActive(true);
                gameScreen[i].SetActive(false);
            }
            if(sendToMainMenu == false)
            {
                Invoke("ReturnToMainMenu", 20);
                sendToMainMenu = true;
            }
            
        }
        for (int i = 0; i < gameScreen.Length; i++)
        {
            gameScreen[i].GetComponent<JumbotronScreen>().killCount.text = numbKills.ToString()+"/40" ;
            gameScreen[i].GetComponent<JumbotronScreen>().headshotCount.text = numbHeadshot.ToString();
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
