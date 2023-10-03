using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private int minutes;
    private float seconds;
    private double milliseconds;

    private void Update()
    {
        FormatTime();

        timerText.text = string.Format("{0:00}:{1:00.00}", minutes, seconds);
    }

    private void FormatTime()
    {
        seconds += Time.deltaTime;

        if (milliseconds >= 10f ) 
        {
            seconds++;
            milliseconds = 0;
        }

        if(seconds >= 60f)
        {
            minutes++;
            seconds = 0;
        }
    }
}