using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    #region variables

    [Header("NPC standard things")]
    public float carefullWalkSpeed;
    public float normalWalkSpeed;
    public float runSpeed;

    [Header("Gun specific code")]
    public float gunBloom;
    public float damagePerShot;

    [Header("'Map info")]
    public Transform mapCentre;
    public float mapRadius;
    public Transform[] importantPlaces;

    [Header("Line of sight info")]
    public float maxDistance;
    public float totalDegrees;
    public float closeDistance;
    public float timeToSeek;

    [Header("Player info")]
    public string playerTag;

    //private variables
    NavMeshAgent navMesh;
    RaycastHit hit;

    //player find stuf
    List<GameObject> players = new List<GameObject>();
    Vector3 lastSeen;

    //timer
    float timerForFindingPlayer;

    //dodge variables
    Vector3 walkPlace;

    #endregion

    #region start, update and other basic functions

    public void Awake()
    {

    }

    public void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {

    }

    public void FixedUpdate()
    {
        TheBrain();
    }

    #endregion

    #region the fucntion that decides everything

    public void TheBrain()
    {
        FindPlayers(players, playerTag, maxDistance, totalDegrees, closeDistance);

        if (players.Count > 1)
        {
            timerForFindingPlayer = timeToSeek;

            GameObject closestPlayer = new GameObject();
            float closestDistance = new float();
            CalculateDistanceToPlayers(players, closestPlayer, closestDistance);

            lastSeen = closestPlayer.transform.position;

            Shooting(closestPlayer.transform, gunBloom);
        }
        else if (timerForFindingPlayer != 0)
        {
            timerForFindingPlayer -= Time.deltaTime;

            Move(lastSeen, navMesh, carefullWalkSpeed);
        }
        else if (importantPlaces.Length != 0)
        {
            int place = Random.Range(0, importantPlaces.Length);

            Move(importantPlaces[place].position, navMesh, runSpeed);
        }
        else
        {
            Roaming(navMesh, mapCentre, mapRadius, normalWalkSpeed);
        }
    }

    #endregion

    #region main functions that get all the info

    /// <summary> finds all players inside of detection </summary>
    public void FindPlayers(List<GameObject> outPlayers, string playerTag, float maxDistance, float maxRotation, float closestDistance)
    {
        GameObject[] playerArray = GameObject.FindGameObjectsWithTag(playerTag);

        foreach (var player in playerArray)
        {
            float angle = Vector3.Angle(transform.forward, player.transform.position);
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (angle < maxRotation && distance < maxDistance)
            {
                outPlayers.Add(player);
            }
            else if (distance < closestDistance)
            {
                outPlayers.Add(player);
            }
        }
    }

    /// <summary> finds closest player inside of detection  </summary>
    public void FindClosestPlayer(GameObject player, string playerTag, float maxDistance, float maxRotation, float closestDistance)
    {
        GameObject[] playerArray = GameObject.FindGameObjectsWithTag(playerTag);
        float nearestPlayerDistance = new float();
        GameObject nearestPlayer = new GameObject();

        foreach (var p in playerArray)
        {
            float angle = Vector3.Angle(transform.forward, p.transform.position);
            float distance = Vector3.Distance(transform.position, p.transform.position);

            if (angle < maxRotation && distance < maxDistance && nearestPlayerDistance > distance)
            {
                nearestPlayer = p;
                nearestPlayerDistance = distance;
            }
            else if (distance < closestDistance && nearestPlayerDistance > distance)
            {
                nearestPlayer = p;
                nearestPlayerDistance = distance;
            }
        }

        player = nearestPlayer;
    }

    /// <summary> finds all players inside of the scene </summary>
    public void FindAllPlayers(GameObject[] playerArray, List<GameObject> playerList)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
        playerArray = players;

        foreach (var player in players)
        {
            playerList.Add(player.gameObject);
        }
    }

    /// <summary> find the closest player to the NPC </summary>
    public void FindNearestPlayer(GameObject player)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
        float nearestPlayerDistance = new float();
        GameObject nearestPlayer = new GameObject();

        foreach (var p in players)
        {
            float distance = Vector3.Distance(transform.position, p.transform.position);

            if (nearestPlayerDistance > distance)
            {
                nearestPlayer = p;
                nearestPlayerDistance = distance;
            }
        }

        player = nearestPlayer;
    }

    /// <summary> calculates the distances between you and all players given and returns 1 player that is the closest </summary>
    public void CalculateDistanceToPlayers(List<GameObject> playersInList, GameObject returnsNearestPlayer, float returnsNearestPlayerDistance)
    {
        GameObject nearestPlayer = new GameObject();
        float nearestPlayerDistance = new float();

        if (playersInList.Count != 0)
        {
            foreach (var player in playersInList)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);

                if (nearestPlayerDistance > distance)
                {
                    nearestPlayerDistance = distance;
                    nearestPlayer = player;
                }
            }
        }

        returnsNearestPlayer = nearestPlayer;
        returnsNearestPlayerDistance = nearestPlayerDistance;
    }

    #endregion

    #region states for the NPC to do/use


    /// <summary> takes a random place on the x and z axis of the map that the NPC is going to walk to </summary>
    public void Roaming(NavMeshAgent agent, Transform centreOfMap, float radius, float moveSpeed)
    {
        Vector3 offset = new Vector3();

        offset.x = Random.Range(-radius, radius) + centreOfMap.position.x;
        offset.z = Random.Range(-radius, radius) + centreOfMap.position.z;

        agent.destination = offset;
        agent.speed = moveSpeed;
    }

    /// <summary> shoots towards the player with bloom </summary>
    public void Shooting(Transform player, float maxBloom)
    {
        Vector3 bloom;
        bloom.x = Random.Range(-player.position.z * 2 * maxBloom, player.position.z * 2 * maxBloom);
        bloom.z = Random.Range(-player.position.z * 2 * maxBloom, player.position.z * 2 * maxBloom);
        bloom.y = Random.Range(-player.position.z * maxBloom, player.position.y * maxBloom);

        if (Physics.Raycast(transform.position, bloom, out hit))
        {
            if (hit.transform.GetComponent<HealthScript>())
            {
                hit.transform.GetComponent<HealthScript>().Health((int)damagePerShot);
            }
        }
    }

    /// <summary> let the NPC walk or run towards a position </summary>
    public void Move(Vector3 placeToWalk, NavMeshAgent agent, float speed)
    {
        agent.destination = placeToWalk;
        agent.speed = speed;
    }

    /// <summary> moving for a little bit to dodge incomming bullets </summary>
    public void Dodge()
    {
        float distance = Vector3.Distance(transform.position, walkPlace);

        if (distance < 2)
        {

        }
    }

    #endregion
}
