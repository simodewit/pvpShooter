using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadPlayerName : MonoBehaviour
{
    public PlayerProperties PlayerProperties;

    public void Awake()
    {
        PlayerProperties = FindAnyObjectByType<PlayerProperties>();
        gameObject.GetComponent<TMP_Text>().text = PlayerProperties._myPlayerProperties["PlayerName"].ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
