using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void Arcade()
    {
        SceneManager.LoadScene("Ethan Level");
    }
    public void Laser()
    {
        SceneManager.LoadScene("Laser_Tag");
    }
    public void Cas()
    {
        SceneManager.LoadScene("Casino");
    }
    public void Space()
    {
        SceneManager.LoadScene("Spaceship");
    }


}
