using UnityEngine;

public class ChangingPoint : MonoBehaviour
{
    #region variables

    [Header("refrences")]
    public Timer timer;
    public float timeInterval;
    public GameObject point;
    public Transform[] places;

    float time;
    bool started;

    #endregion

    #region start and update

    public void Update()
    {
        FirstRandomize();
        Randomize();
    }

    #endregion

    #region randomizers

    public void FirstRandomize()
    {
        if (timer.startGame && !started)
        {
            int index = Random.Range(0, places.Length);
            point.transform.position = places[index].position;

            started = true;
            time = timeInterval;
        }
    }

    public void Randomize()
    {
        if (time <= 0)
        {
            time = timeInterval;

            int index = Random.Range(0, places.Length);
            point.transform.position = places[index].position;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    #endregion
}
