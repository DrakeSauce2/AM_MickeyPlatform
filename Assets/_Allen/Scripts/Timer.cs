using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    [SerializeField] private TextMeshProUGUI timerText;
    
    private int minutes;
    private float seconds;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Update()
    {
        FormatTime();

        timerText.text = string.Format("{0:00}:{1:00.00}", minutes, seconds);
    }

    private void FormatTime()
    {
        seconds += Time.deltaTime;

        if(seconds >= 60f)
        {
            minutes++;
            seconds = 0;
        }
    }

    public void CompareTime(TimeKeeper timeKeeper)
    {
        if(timeKeeper.GetBestMinutes() == 0 && TimeManager.Instance.timeKeepers[GameManager.Instance.level - 1].GetBestSeconds() == 0)
        {
            TimeManager.Instance.timeKeepers[GameManager.Instance.level - 1].SetTime(minutes, seconds);
        }

        if(minutes <= timeKeeper.GetBestMinutes())
        {
            if (seconds < timeKeeper.GetBestSeconds())
            {
                TimeManager.Instance.timeKeepers[GameManager.Instance.level - 1].SetTime(minutes, seconds);
            }
        }
    }

    public string GetTimerText()
    {
        return timerText.text;
    }

}
