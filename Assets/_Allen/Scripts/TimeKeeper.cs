using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/TimeKeeper")]
public class TimeKeeper : ScriptableObject
{
    public int minutes;
    public float seconds;
    [Space]
    public int restarts;

    public int GetBestMinutes() => minutes;
    public float GetBestSeconds() => seconds;  

    public int GetRestarts() => restarts;

    public void SetTime(int min, float sec)
    {
        minutes = min;
        seconds = sec;
    }

    public void SetRetries(int tries)
    {
        restarts = tries;
    }
}
