using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTeamColor : MonoBehaviour
{
    public Color color;
    public GameObject team;
 
    public void OnClick()
    {
        team.GetComponent<Image>().color = color;
    }
}
