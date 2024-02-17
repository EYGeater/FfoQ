using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    //singleton
    public static PlayerTracker Main;

    public PlayerController player1;
    public PlayerController player2;

    private void Start()
    {
        Main = this;
    }

    public void PlayerDeath()
    {
        if(!player1.alive && !player2.alive)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game over");
    }
}
