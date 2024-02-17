using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcShotScript : ShootScript
{
    protected override void Start()
    {
        playerController.greenEvent += Shoot;
    }
}
