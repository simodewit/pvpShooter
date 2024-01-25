using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class JumbotronScreen : MonoBehaviour
{
    public TMP_Text time, killCount, headshotCount, winHeadshots, winTime;
    public GameObject youWonPanel;
    private float currentTime;

    public bool isWon;

    private void Start()
    {
        currentTime = 0;
    }
    void Update()
    {
        if(isWon == false)
        {
            currentTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Display the formatted time in your TMP_Text
            time.text = formattedTime;
        }
    }
}
