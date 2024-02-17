using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShotScript : ShootScript
{
    protected override void Start()
    {
        playerController.yellowEvent += Shoot;
    }
}
