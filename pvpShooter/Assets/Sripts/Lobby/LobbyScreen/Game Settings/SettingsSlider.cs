using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsSlider : MonoBehaviour
{
    public TMP_Text text;
    public string greatness;
    public string propertyName;
    public RoomProperties roomProperties;
    public void Start()
    {
        text.text = gameObject.GetComponent<Slider>().value.ToString()+ " " + greatness;
    }
    public void SliderValueChange(float value)
    {
        text.text = value.ToString() + " " + greatness;
        roomProperties._myRoomProperties[propertyName] = value;
    }
}
