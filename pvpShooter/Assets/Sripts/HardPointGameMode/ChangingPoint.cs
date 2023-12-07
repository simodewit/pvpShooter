using System;
using UnityEngine;

public class ChangingPoint : MonoBehaviour
{
    #region variables

    [Header("refrences")]
    public Timer timer;
    public GameObject point;

    public TimesForPointChange[] times;

    #endregion

    #region start and update

    public void Start()
    {
        FirstRandomize();
    }

    public void Update()
    {
        Randomize();
    }

    #endregion

    #region randomizers

    public void FirstRandomize()
    {
        int index = UnityEngine.Random.Range(0, times[0].placesToSpawn.Length);

        point.transform.position = times[0].placesToSpawn[index].position;
        times[0].hasCompleted = true;
    }

    public void Randomize()
    {
        foreach(var time in times)
        {
            if (!time.hasCompleted && time.timeToSpawn == timer.text.text)
            {
                int index = UnityEngine.Random.Range(0, time.placesToSpawn.Length);
                point.transform.position = time.placesToSpawn[index].position;
                time.hasCompleted = true;
            }
        }
    }

    #endregion
}

[Serializable]
public class TimesForPointChange
{
    [Header("format for time is (minutes:seconds). example = 2:30, or 4:50, or 12:30")]
    public string timeToSpawn;

    [Header("all the places the point can spawn on the time given above")]
    public Transform[] placesToSpawn;

    [Header("code related dont touch")]
    public bool hasCompleted;
}
