using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomProperties : MonoBehaviour
{
    public ExitGames.Client.Photon.Hashtable _myRoomProperties = new ExitGames.Client.Photon.Hashtable();

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
