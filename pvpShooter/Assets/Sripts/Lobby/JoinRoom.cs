using UnityEngine;

public class JoinRoom : MonoBehaviour
{
    public GameObject team1, team2;
    public GameObject playerPrefab;
    public string playerButtonName;
    public Transform spawnPlace;
    public GameObject spawnedButton;

    public float yRotationOffset;
    public void Awake()
    {
        Instantiate(playerPrefab, spawnPlace.position, new Quaternion(0, yRotationOffset, 0, 0));
    }
}
