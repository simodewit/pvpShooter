using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<TeamSide>().InTeamA)
        {
            //gives points to counter team A
        }
        else
        {
            //gives points to counter team B
        }
    }
}
