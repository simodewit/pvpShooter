using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectFlagPlace : MonoBehaviour
{
    public bool teamA;
    public string flagPrefabName;
    public TextMeshProUGUI counter;

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == flagPrefabName)
        {
            //counter +1
            Destroy(other.gameObject);
        }
    }
}
