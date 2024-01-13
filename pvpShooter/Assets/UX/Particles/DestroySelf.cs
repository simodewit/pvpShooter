using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private float timeStamp;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        timeStamp = Time.time + cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStamp < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
