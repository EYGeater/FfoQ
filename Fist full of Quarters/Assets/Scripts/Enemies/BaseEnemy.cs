using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public EnemyData enemyData;
    private int health;

    private void Start()
    {
        health = enemyData.maxHealth;
    }

    public void ChangeHealth(int delta)
    {
        health += delta;
        if(health < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
