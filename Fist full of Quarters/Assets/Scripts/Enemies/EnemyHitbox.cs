using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour, IShootable
{
    public BaseEnemy enemy;
    public float damageMultiplier = 1f;

    public void OnShot(GameObject shot)
    {
        enemy.ChangeHealth((int)(damageMultiplier * 1f));
    }
}
