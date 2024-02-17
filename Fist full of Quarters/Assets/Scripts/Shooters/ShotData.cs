using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShotData")]
public class ShotData : ScriptableObject
{
    public float speed;
    public float cooldown;
    public float maxDistance;
}
