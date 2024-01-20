using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameScript : MonoBehaviour
{
    public int numbKills;
    public SpawnEnemy enemySpawner;

    public void OnKill()
    {
        if (numbKills == enemySpawner.maxSpawns - 10)
        {
            //10 kills remaining
        }
        if (numbKills == enemySpawner.maxSpawns - 5)
        {
            //5 kills remaining
        }
        if (numbKills == enemySpawner.maxSpawns)
        {
            //Game won
            print("Game won at " + Time.time + " With "+ numbKills + " kills.");
        }
    }
}
