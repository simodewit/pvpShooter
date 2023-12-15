using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    #region variables

    [Header("counters")]
    public Counter counterTeamA;
    public Counter counterTeamB;

    [Header("tags")]
    public string tagNameTeamA;
    public string tagNameTeamB;

    [Header("Points per second")]
    public float points;

    //lists
    List<GameObject> teamA = new List<GameObject>();
    List<GameObject> teamB = new List<GameObject>();

    #endregion

    #region start and update

    public void FixedUpdate()
    {
        if (teamA.Count == 0 && teamB.Count != 0)
        {
            counterTeamA.points += points;
        }
        else if (teamA.Count != 0 && teamB.Count == 0)
        {
            counterTeamB.points += points;
        }
    }

    #endregion

    #region collision

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagNameTeamA)
        {
            teamA.Add(other.gameObject);
        }
        else if (other.tag == tagNameTeamB)
        {
            teamB.Add(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == tagNameTeamA)
        {
            teamA.Add(other.gameObject);
        }
        else if (other.tag == tagNameTeamB)
        {
            teamB.Add(other.gameObject);
        }
    }

    #endregion
}
