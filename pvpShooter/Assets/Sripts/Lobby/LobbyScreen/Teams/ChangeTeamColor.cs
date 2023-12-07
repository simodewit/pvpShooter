using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTeamColor : MonoBehaviour
{
    public Color color, panelColor;
    public GameObject team, teamPanel;
 
    public void OnClick()
    {
        team.GetComponent<Image>().color = color;
        teamPanel.GetComponent<Image>().color = panelColor;
    }
}
