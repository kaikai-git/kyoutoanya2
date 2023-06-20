using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSysytem : MonoBehaviour
{
    public void EndGame()
    {

        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
