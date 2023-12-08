using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounce : MonoBehaviour
{
    public float bounceHeight = 20.0f;
    public float bounceSpeed = 2.0f;

    private RectTransform rectTransform;
    private Vector3 initialPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition;
    }

    private void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);
    }
}

