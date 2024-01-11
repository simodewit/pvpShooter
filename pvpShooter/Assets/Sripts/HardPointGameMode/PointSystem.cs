using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    #region variables

    public Counter counterPlayerTeam;
    public Counter counterEnemieTeam;
    public float timePerPoint;
    public string playerTag;

    List<GameObject> allEnemies = new List<GameObject>();
    bool player;
    bool enemies;
    float timer;

    #endregion

    public void Start()
    {
        //get the counters
    }

    public void Update()
    {
        if (allEnemies.Count == 0)
        {
            enemies = false;
        }
        else
        {
            enemies = true;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timePerPoint;
        }

        if (player && !enemies)
        {
            if (timer <= 0)
            {
                //counterPlayerTeam.points += 1;
            }
        }
        if (!player && enemies)
        {
            if (timer <= 0)
            {
                //counterEnemieTeam.points += 1;
            }
        }
    }

    #region collision

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            player = true;
        }
        else
        {
            allEnemies.Add(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag)
        {
            player = false;
        }
        else
        {
            allEnemies.Remove(other.gameObject);
        }
    }

    #endregion
}
