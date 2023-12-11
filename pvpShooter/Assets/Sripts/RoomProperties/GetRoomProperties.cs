using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRoomProperties : MonoBehaviour
{
    public RoomProperties roomProperties;
    public float test;
    // Start is called before the first frame update
    void Start()
    {
        roomProperties = FindAnyObjectByType<RoomProperties>();
        test = (float) roomProperties._myRoomProperties["GameLength"];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
