using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcShot : Shot
{
    private Rigidbody rb;
    public override void Fire(Vector3 forward, ShotData shotData)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(forward, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyShot();
    }

    public override void DestroyShot()
    {
        gameObject.SetActive(false);
    }
}
