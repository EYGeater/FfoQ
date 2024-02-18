using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shot : MonoBehaviour
{
    public abstract void Fire(Vector3 forward, ShotData shotData);
    public abstract void DestroyShot();

    public void ShootContact(Collider other)
    {
        IShootable shootable = other.gameObject.GetComponent<IShootable>();
        if(shootable != null) shootable.OnShot(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        ShootContact(other);
        DestroyShot();
    }
}
