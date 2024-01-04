using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProperties : MonoBehaviour
{
    public ExitGames.Client.Photon.Hashtable _myPlayerProperties = new ExitGames.Client.Photon.Hashtable();

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            // spawn with right name
        }
    }
}

