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

    #region start and update

    public void Start()
    {
        GetsInfoFromRoom();
        ConvertTime(0, waitingSeconds);
    }

    public void Update()
    {
        StartOfGame();
        MidGame();
    }

    #endregion

    #region start of game

    public void GetsInfoFromRoom()
    {
        //ask info
    }

    public void StartOfGame()
    {
        if (everybodyHasLoadedIn && waitingSeconds > 0)
        {
            waitingSeconds -= Time.deltaTime;

            ConvertTime(0, waitingSeconds);
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
                seconds = 60;
            }
            else
            {
                seconds = 0;
                minutes = 0;

                //sould end the game or go in kill cam
            }
        }

        ConvertTime(minutes, seconds);
    }

    #endregion

    #region converter

    public void ConvertTime(float minutes, float seconds)
    {
        if (minutes >= 10)
        {
            timeInString += minutes;
        }
        else if (minutes < 10)
        {
            timeInString += "0" + minutes;
        }

        timeInString += ":";

        if (seconds < 10)
        {
            timeInString += "0" + (int)seconds;
        } 
        else if (seconds > 59)
        {
            timeInString += "59";
        }
        else
        {
            timeInString += (int)seconds;
        }

        text.text = timeInString;
        timeInString = "";
    }

    #endregion
}
