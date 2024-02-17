using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMeter : MonoBehaviour
{
    public int maxMeter;
    public int startingMeter;
    public int currMeter;
    private Image meterImage;

    public delegate void MeterAtZeroEvent();
    public MeterAtZeroEvent meterAtZeroEvent;

    public delegate void MeterAtFullEvent();
    public MeterAtFullEvent meterAtFullEvent;

    private void Start()
    {
        meterImage = GetComponent<Image>();
        currMeter = startingMeter;
        meterImage.fillAmount = (float)currMeter / (float)maxMeter;
    }

    public void ChangeMeter(int delta)
    {
        currMeter += delta;
        meterImage.fillAmount = (float)currMeter / (float)maxMeter;

        if(currMeter <= 0)
        {
            meterAtZeroEvent?.Invoke();
        }

        if(currMeter >= maxMeter)
        {
            meterAtFullEvent?.Invoke();
        }
    }
}
