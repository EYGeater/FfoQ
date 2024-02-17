using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShotScript : ShootScript
{
    public PlayerController playerController;
    public ObjectPool pool;
    private Coroutine moveRoutine;

    private void Start()
    {
        playerController.yellowEvent += Shoot;
    }
    public override void Shoot()
    {
        if (!canShoot) return;
        GameObject shot = pool.PullFromPool();
        if(shot != null)
        {
            shot.SetActive(true);
            shot.transform.position = shootPoint.position;
            shot.GetComponent<Shot>().Fire(playerController.transform.forward, shotData);

            StartCooldown();
        }
    }
}
