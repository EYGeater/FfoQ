using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlickSpin : MonoBehaviour
{
    // speed for pickup is 25
    // speed for flick is 70
    public int rotationSpeed = 25;
    public bool SpinX;
    private void FixedUpdate()
    {
        if(SpinX)
        {
            XRotate();
        }
        else
        {
            ZRotate();
        }
    }
   
    public void ZRotate()
    {
        transform.Rotate(rotationSpeed * new Vector3(0, 0, 10) * Time.deltaTime, Space.Self);
    }

    public void XRotate()
    {
        transform.Rotate(rotationSpeed * new Vector3(10, 0, 0) * Time.deltaTime, Space.Self);
    }
}
