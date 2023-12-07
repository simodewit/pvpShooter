using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTeam : MonoBehaviour
{
    public Button player;
    public Transform team1Panel, team2Panel;
    public Button team1, team2;

    public void PlayerSwitchTeam()
    {
        if (player != null)
        {
            if (player.GetComponent<PlayerTeam>().whatTeam == 1)
            {
                player.GetComponent<PlayerTeam>().whatTeam = 2;
                player.GetComponent<Image>().color = team2.GetComponent<Image>().color;
                player.GetComponent<Transform>().SetParent(team2Panel);
            }
            else
            {
                player.GetComponent<PlayerTeam>().whatTeam = 1;
                player.GetComponent<Image>().color = team1.GetComponent<Image>().color;
                player.GetComponent<Transform>().SetParent(team1Panel);
            }
        }
    }
}
