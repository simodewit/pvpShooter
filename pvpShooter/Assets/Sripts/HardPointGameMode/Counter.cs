using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public float points;
    TextMeshProUGUI text;

    public void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        text.text = points.ToString();
    }
}
