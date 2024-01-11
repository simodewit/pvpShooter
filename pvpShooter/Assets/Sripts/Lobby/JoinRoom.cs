using UnityEngine;

public class JoinRoom : MonoBehaviour
{
    public GameObject team1, team2;
    public GameObject playerPrefab;
    public string playerButtonName;
    public Transform spawnPlace;
    public GameObject spawnedButton;

    public void Awake()
    {
        Instantiate(playerPrefab, spawnPlace.position, new Quaternion(0, 0, 0, 0));
    }
}
