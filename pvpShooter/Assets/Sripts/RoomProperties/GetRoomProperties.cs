using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRoomProperties : MonoBehaviour
{
    public RoomProperties roomProperties;
    public PlayerProperties playerProperties;
    public float test;
    public string playerTest;
    public int playerTeamTest;
    // Start is called before the first frame update
    void Start()
    {
        roomProperties = FindAnyObjectByType<RoomProperties>();
        playerProperties = FindAnyObjectByType<PlayerProperties>();
        test = (float) roomProperties._myRoomProperties["GameLength"];
    }

    // Update is called once per frame
    void Update()
    {
        playerTest = (string)playerProperties._myPlayerProperties["PlayerName"];
        playerTeamTest = (int)playerProperties._myPlayerProperties["Team"];
    }
}
