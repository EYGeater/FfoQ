using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaQuit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }
}
