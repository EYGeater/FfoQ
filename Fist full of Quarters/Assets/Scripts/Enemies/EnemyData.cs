using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [Tooltip("The amount of time that passes between rerouting its path")]
    public float rerouteTime;
    public int maxHealth;
}
