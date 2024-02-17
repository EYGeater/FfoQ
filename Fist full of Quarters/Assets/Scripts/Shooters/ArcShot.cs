using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcShot : Shot { 

    private Coroutine gravityRoutine;
    private Rigidbody rb;
    public override void Fire(Vector3 forward, ShotData shotData)
    {
        ArcShotData arcShotData = (ArcShotData)shotData;
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        Vector3 launchVector = forward + new Vector3(0f, ((ArcShotData)shotData).upForce, 0f);
        rb.AddForce(launchVector * shotData.speed, ForceMode.Impulse);
        if (gravityRoutine != null) StopCoroutine(gravityRoutine);
        gravityRoutine = StartCoroutine(GravityRoutine(arcShotData));
    }

    private IEnumerator GravityRoutine(ArcShotData shotData)
    {
        while (true)
        {
            rb.AddForce(Vector3.down * shotData.gravityScale, ForceMode.Acceleration);

            //wait for physics frame
            yield return new WaitForFixedUpdate();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        DestroyShot();
    }

    public override void DestroyShot()
    {
        if (gravityRoutine != null) StopCoroutine(gravityRoutine);
        gameObject.SetActive(false);
    }
}
