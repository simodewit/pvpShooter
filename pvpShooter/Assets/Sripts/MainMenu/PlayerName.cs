using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    public PlayerProperties PlayerProperties;
   public void ApplyName(string input)
    {
        PlayerProperties._myPlayerProperties["PlayerName"] = input; 
    }
}
