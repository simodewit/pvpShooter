using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region variables

    [Header("TimerUI")]
    public TextMeshProUGUI text;

    [Header("start waiting time")]
    public float waitingSeconds;

    [Header("start time")]
    public float minutes;
    public float seconds;

    [Header("DO NOT TOUCH, code related")]
    public bool everybodyHasLoadedIn;
    public bool startGame;

    //private variables
    string timeInString;

    #endregion

    #region start

    public void Start()
    {
        ConvertTime(0, waitingSeconds);
    }

    #endregion

    #region update

    public void Update()
    {
        StartOfGame();
        MidGame();
    }

    #endregion

    #region start of game

    public void StartOfGame()
    {
        if (everybodyHasLoadedIn)
        {
            waitingSeconds -= Time.deltaTime;
        }

        if (waitingSeconds <= 0)
        {
            startGame = true;
        }
    }

    #endregion

    #region in the middle of the gameplay

    public void MidGame()
    {
        if(!startGame)
        {
            return;
        }

        seconds -= Time.deltaTime;

        if(seconds < 1)
        {
            if (minutes > 0)
            {
                minutes -= 1;
                seconds = 61;
            }
            else
            {
                //game over
            }
        }

        ConvertTime(minutes, seconds);
    }

    #endregion

    #region converter

    public void ConvertTime(float minutes, float seconds)
    {
        if(minutes >= 10 && seconds >= 10)
        {
            timeInString = minutes.ToString() + ":" + seconds.ToString();
        }
        if (minutes >= 10 && seconds <= 10)
        {
            timeInString = minutes.ToString() + ":0" + seconds.ToString();
        }
        if (minutes <= 10 && seconds >= 10)
        {
            timeInString = "0" + minutes.ToString() + ":" + seconds.ToString();
        }
        if (minutes <= 10 && seconds <= 10)
        {
            timeInString = "0" + minutes.ToString() + ":0" + seconds.ToString();
        }
    }

    #endregion
}
