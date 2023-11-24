using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingPoint : MonoBehaviour
{
    public Transform[] placesToSpawn;

    int currentIndex;

    public void Start()
    {
        
    }

    public void Randomize()
    {
        int index = Random.Range(0,placesToSpawn.Length);

        if(index == currentIndex)
        {
            Randomize();
        }

        currentIndex = index;


    }
}
