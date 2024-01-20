using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float spawnInterval;
    public int totalEnemies, maxSpawns, currentSpawns;
    public Timer time;
    public GameObject enemyPrefab;
    public List<GameObject> enemies = new List<GameObject>();
    public List<Transform> spawns = new List<Transform>();

    float timer;
    bool canSpawn;

    public void Start()
    {
        time = FindAnyObjectByType<Timer>();
    }

    public void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (!time.startGame)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = spawnInterval;
            canSpawn = true;
        }

        if (enemies.Count < totalEnemies && canSpawn && currentSpawns < maxSpawns)
        {
            int random = Random.Range(0, spawns.Count);

            currentSpawns += 1;
            GameObject enemy = Instantiate(enemyPrefab, spawns[random].position , Quaternion.identity);
            enemies.Add(enemy);

            canSpawn = false;
        }
    }
}
