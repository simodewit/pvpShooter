using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGamme : MonoBehaviour
{
    public void CloseGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
