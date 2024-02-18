using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootScript : MonoBehaviour
{
    public PlayerController playerController;
    public ObjectPool pool;
    public ShotData shotData;
    public Transform shootPoint;
    public CoinMeter coinMeter;

    protected bool canShoot = true;
    public void StartCooldown()
    {
        StartCoroutine(CooldownRoutine());
    }

    protected abstract void Start();
    protected IEnumerator CooldownRoutine()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotData.cooldown);
        canShoot = true;
    }

    public void Shoot()
    {
        if (!canShoot) return;
        GameObject shot = pool.PullFromPool();
        if (shot != null)
        {
            shot.SetActive(true);
            shot.transform.position = shootPoint.position;
            shot.GetComponent<Shot>().Fire(playerController.transform.forward, shotData);


            coinMeter.ChangeMeter(-1);
            StartCooldown();
        }
    }
}
