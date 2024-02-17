using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShot : Shot
{
    private float distanceTraveled = 0f;
    private Coroutine moveRoutine;
    public override void Fire(Vector3 forward, ShotData shotData)
    {
        distanceTraveled = 0f;
        moveRoutine = StartCoroutine(MoveRoutine(forward, shotData));
    }

    private IEnumerator MoveRoutine(Vector3 forward, ShotData shotData)
    {
        while (true)
        {
            Vector3 moveVector = shotData.speed * Time.deltaTime * forward;
            transform.position += moveVector;
            distanceTraveled += moveVector.magnitude;

            if (distanceTraveled > shotData.maxDistance) DestroyShot();

            //wait a frame before progressing
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyShot();
    }

    public override void DestroyShot()
    {
        if (moveRoutine != null) StopCoroutine(moveRoutine);
        gameObject.SetActive(false);
    }
}
