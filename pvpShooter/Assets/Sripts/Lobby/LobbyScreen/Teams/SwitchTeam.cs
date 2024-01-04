using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTeam : MonoBehaviour
{
    public Button player;
    public Transform team1Panel, team2Panel;
    public Button team1, team2;
    public PlayerProperties[] playerProperties;

  
    public void PlayerSwitchTeam()
    {
        Debug.Log(player.GetComponentInChildren<TMP_Text>().text.ToString());
        playerProperties = FindObjectsOfType<PlayerProperties>();

        if (player != null)
        {
            if (player.GetComponent<PlayerTeam>().whatTeam == 1)
            {
                for (int i = 0;i < playerProperties.Length; i++)
                {
                    if (playerProperties[i]._myPlayerProperties["PlayerName"] == player.GetComponentInChildren<TMP_Text>().text.ToString())
                    {
                        playerProperties[i]._myPlayerProperties["Team"] = 2;
                    }
                }
                player.GetComponent<PlayerTeam>().whatTeam = 2;
                player.GetComponent<Image>().color = team2.GetComponent<Image>().color;
                player.GetComponent<Transform>().SetParent(team2Panel);
            }
            else
            {
                for (int i = 0; i < playerProperties.Length; i++)
                {
                    if (playerProperties[i]._myPlayerProperties["PlayerName"] == player.GetComponentInChildren<TMP_Text>().text.ToString())
                    {
                        playerProperties[i]._myPlayerProperties["Team"] = 1;
                    }
                }
                player.GetComponent<PlayerTeam>().whatTeam = 1;
                player.GetComponent<Image>().color = team1.GetComponent<Image>().color;
                player.GetComponent<Transform>().SetParent(team1Panel);
            }
        }
    }
}
