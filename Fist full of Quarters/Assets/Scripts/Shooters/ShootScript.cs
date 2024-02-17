using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootScript : MonoBehaviour
{
    public ShotData shotData;
    public Transform shootPoint;

    protected bool canShoot = true;
    public abstract void Shoot();
    public void StartCooldown()
    {
        StartCoroutine(CooldownRoutine());
    }
    protected IEnumerator CooldownRoutine()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotData.cooldown);
        canShoot = true;
    }
}
