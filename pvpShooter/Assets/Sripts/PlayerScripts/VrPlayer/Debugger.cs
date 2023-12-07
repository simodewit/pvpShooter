using Photon.Pun;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviourPunCallbacks
{
    #region variables

    [Header("UiPanels")]
    public GameObject UiPanel;
    public TextMeshProUGUI timeUI;
    public TextMeshProUGUI consoleUI;
    public ScrollRect scroll;

    //timer variables
    string timerInString = "0.0.0";
    float time;
    int minutes;
    int seconds;
    int miliseconds;

    bool canScroll;

    #endregion

    #region update

    private void Update()
    {
        Timer();
        ScrollDown();
    }

    #endregion

    #region timer

    void Timer()
    {
        time += Time.deltaTime;

        miliseconds = (int)(time * 100) % 100;
        if (time >= 60)
        {
            time -= 60;
            minutes += 1;
        }
        seconds = (int)time;

        timerInString = minutes.ToString() + ":" + seconds.ToString() + ":" + miliseconds.ToString();
        timeUI.text = timerInString;
    }

    #endregion

    #region functions to use in code

    public void Print(string s)
    {
        consoleUI.text += timerInString + ": " + s + "<br>";
    }

    public void IntPrint(int i)
    {
        consoleUI.text += timerInString + ": " + i.ToString() + "<br>";
    }

    public void FloatPrint(float f)
    {
        consoleUI.text += timerInString + ": " + f.ToString() + "<br>";
    }

    public void BoolPrint(bool b)
    {
        consoleUI.text += timerInString + ": " + b.ToString() + "<br>";
    }

    public void Vector2Print(Vector2 v)
    {
        consoleUI.text += timerInString + ": " + v.ToString() + "<br>";
    }

    public void Vector3Print(Vector3 v)
    {
        consoleUI.text += timerInString + ": " + v.ToString() + "<br>";
    }

    public void ErrorFinder(Action function)
    {
        try
        {
            function();
        }
        catch (Exception e)
        {
            consoleUI.text += timerInString + ": " + e.Message + "<br>";
        }
    }

    #endregion

    #region scrollInputs

    public void ScrollDown()
    {
        if (!canScroll)
        {
            scroll.verticalScrollbar.value = 0;
        }
    }

    public void OnValueChange(Vector2 v)
    {
        if(v.x > 0)
        {
            canScroll = true;
        }
        else
        {
            canScroll = false;
        }
    }

    #endregion
}
