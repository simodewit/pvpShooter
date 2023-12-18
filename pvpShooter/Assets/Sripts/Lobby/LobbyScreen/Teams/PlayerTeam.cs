using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeam : MonoBehaviour
{
    public Button switchTeam;
    public int whatTeam;

    public void Awake()
    {
        switchTeam = FindAnyObjectByType<SwitchTeam>().GetComponent<Button>();
    }
    public void SelectPlayer()
    {
        switchTeam.GetComponent<SwitchTeam>().player = gameObject.GetComponent<Button>();
    }
}
