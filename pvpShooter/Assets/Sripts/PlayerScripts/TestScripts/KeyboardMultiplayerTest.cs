using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMultiplayerTest : MonoBehaviour
{
    public float factor;

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0,0,1) * factor;
        }
    }
}
