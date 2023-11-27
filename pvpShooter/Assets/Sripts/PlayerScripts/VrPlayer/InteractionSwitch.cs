using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InteractionSwitch : MonoBehaviour
{
    public GameObject ray;
    public string gameobjectWithDetails;

    SceneDetails sceneDescriptions;

    public void Start()
    {
        sceneDescriptions = GameObject.Find(gameobjectWithDetails).GetComponent<SceneDetails>();

        if(sceneDescriptions.sceneStartsInUI)
        {
            sceneDescriptions.enabled = true;
        }
        else
        {
            sceneDescriptions.enabled = false;
        }
    }
}
