using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionSwitch : MonoBehaviour
{
    [Header("refrences")]
    public XRDirectInteractor grabInter;
    public GameObject ray;
    public string gameobjectWithDetails;

    //privates
    SceneDetails sceneDescriptions;

    public void Start()
    {
        sceneDescriptions = GameObject.Find(gameobjectWithDetails).GetComponent<SceneDetails>();

        if(sceneDescriptions.sceneStartsInUI)
        {
            grabInter.enabled = false;
            ray.SetActive(true);
        }
        else
        {
            grabInter.enabled = true;
            ray.SetActive(false);
        }
    }

    public void Switch()
    {
        if(ray.activeSelf)
        {
            grabInter.enabled = true;
            ray.SetActive(false);
        }
        else
        {
            grabInter.enabled = false;
            ray.SetActive(true);
        }
    }
}
