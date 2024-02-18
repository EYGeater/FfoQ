using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour, IShootable
{
    public BaseEnemy enemy;
    public float damageMultiplier = 1f;

    public void OnShot(GameObject shot)
    {
        //Debug.Log("Dealt " + (-(int)(damageMultiplier * 1f)) + " damage.");
        enemy.ChangeHealth(-1* (int)(damageMultiplier * 1f));
    }
}
