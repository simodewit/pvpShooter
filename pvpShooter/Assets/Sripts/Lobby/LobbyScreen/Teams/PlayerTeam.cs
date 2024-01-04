using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeam : MonoBehaviour
{
    public SwitchTeam switchTeam;
    public int whatTeam;

    public void Awake()
    {
        switchTeam = FindAnyObjectByType<SwitchTeam>();
    }
    public void Start()
    {
        switchTeam = FindAnyObjectByType<SwitchTeam>();
    }
    public void SelectPlayer()
    {
        switchTeam.GetComponent<SwitchTeam>().player = gameObject.GetComponent<Button>();
    }
}
