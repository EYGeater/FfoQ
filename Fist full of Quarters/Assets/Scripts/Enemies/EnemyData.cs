using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [Tooltip("The amount of time that passes between rerouting its path")]
    public float rerouteTime;
    public int maxHealth;
    [Tooltip("When within this distance from a player, they will stop moving and attack")]
    public float distToAttack;
    public float attackDuration;
}
