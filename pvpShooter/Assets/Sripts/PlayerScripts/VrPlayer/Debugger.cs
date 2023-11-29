using Photon.Pun;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.InputSystem.InputAction;

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

    #endregion

    #region update

    private void Update()
    {
        Timer();
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

    #region code for disabling and enabling the debug panel

    public void ToggleDebugger(CallbackContext c)
    {
        if(c.started)
        {
            EnableDisablePanel();
        }
    }

    public void EnableDisablePanel()
    {
        if(UiPanel.activeSelf)
        {
            UiPanel.SetActive(false);
        }
        else
        {
            UiPanel.SetActive(true);
        }
    }

    #endregion

    #region functions to use in code

    public void VrPrint(string s)
    {
        consoleUI.text += timerInString + ": " + s + "<br>";
        scroll.verticalScrollbar.value = 0;
    }

    public void ShowVariableInt(int i)
    {
        consoleUI.text += timerInString + ": " + i.ToString() + "<br>";
        scroll.verticalScrollbar.value = 0;
    }

    public void ShowVariableFloat(float f)
    {
        consoleUI.text += timerInString + ": " + f.ToString() + "<br>";
        scroll.verticalScrollbar.value = 0;
    }

    public void ShowVariableBool(bool b)
    {
        consoleUI.text += timerInString + ": " + b.ToString() + "<br>";
        scroll.verticalScrollbar.value = 0;
    }

    public void CatchErrors(Action function)
    {
        try
        {
            function();
        }
        catch (Exception e)
        {
            consoleUI.text += timerInString + ": " + e.Message + "<br>";
            scroll.verticalScrollbar.value = 0;
        }
    }

    #endregion
}
