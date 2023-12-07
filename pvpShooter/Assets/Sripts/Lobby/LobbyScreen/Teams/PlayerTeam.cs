using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeam : MonoBehaviour
{
    public int whatTeam;
    public void SelectPlayer(Button switchButton)
    {
        switchButton.GetComponent<SwitchTeam>().player = gameObject.GetComponent<Button>();
    }
}
