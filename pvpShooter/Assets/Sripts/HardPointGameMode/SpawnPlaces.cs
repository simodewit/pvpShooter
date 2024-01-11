using UnityEngine;

public class SpawnPlaces : MonoBehaviour
{
    #region variables

    public GameObject playerPrefab;

    //privates
    float timer;

    #endregion

    #region start

    public void Start()
    {
        Instantiate(playerPrefab);
    }

    #endregion
}
