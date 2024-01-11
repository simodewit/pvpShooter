using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Spawns : MonoBehaviour
{
    Transform player;
    SpawnEnemy spawnManager;
    public float minDistance;
    public bool isInList;

    public void Start()
    {
        spawnManager = transform.parent.GetComponent<SpawnEnemy>();
        player = FindAnyObjectByType<ContinuousMoveProviderBase>().transform;
    }

    public void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance >= minDistance && !isInList)
        {
            spawnManager.spawns.Add(transform);
            isInList = true;
        }
        else if(distance < minDistance && isInList)
        {
            spawnManager.spawns.Remove(transform);
            isInList = false;
        }
    }
}
