using UnityEngine;

public class PointSystem : MonoBehaviour
{
    bool teamAInside;
    bool teamBInside;

    public void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<TeamSide>() != null)
        {
            if (other.GetComponent<TeamSide>().InTeamA)
            {
                teamAInside = true;

                if (!teamBInside)
                {
                    //gives points to counter team A
                }
            }
            else
            {
                teamBInside = true;

                if (!teamAInside)
                {
                    //gives points to counter team B
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TeamSide>().InTeamA)
        {
            teamAInside = false;
        }
        else
        {
            teamBInside = false;
        }
    }
}
