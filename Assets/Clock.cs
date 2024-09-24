using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    public Transform secondArm;
    [SerializeField]
    public Transform minuteArm;
    [SerializeField]
    public Transform hourArm;

    private int previousSeconds;
    private int timeInSeconds;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RotateHands();
        ConverTimeToSeconds();
    }


    private int ConverTimeToSeconds()
    {
        int currentSeconds = DateTime.Now.Second;
        int currentMinute = DateTime.Now.Minute;
        int currentHour = DateTime.Now.Hour;

        if (currentHour >=12)
        {
            currentHour -= 12;
        }

        timeInSeconds = currentSeconds + (currentMinute * 60) + (currentHour * 60 * 60);

        return timeInSeconds;
    }
  
    void RotateHands()
    {
        float secondHandPerSecond = 360f / 60f;
        float minuteHandPerSecond = 360f / (60f * 60f);
        float hourHandPerSecond = 360f / (60f * 60f * 12f);

        if (timeInSeconds != previousSeconds)
        {
            Debug.Log(timeInSeconds);
            secondArm.localRotation = Quaternion.Euler(timeInSeconds * secondHandPerSecond, 0, 0);
            minuteArm.localRotation = Quaternion.Euler(timeInSeconds * minuteHandPerSecond, 0, 0);
            hourArm.localRotation = Quaternion.Euler(timeInSeconds * hourHandPerSecond, 0, 0); 
        }
    }
}
