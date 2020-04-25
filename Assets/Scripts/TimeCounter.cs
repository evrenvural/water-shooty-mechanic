using System;
using UnityEngine;

public static class TimeCounter
{
    private static float time = 0.0f;

    public static int CountSeconds()
    {
        time += Time.deltaTime;
        int seconds = Convert.ToInt32(time % 60);

        if(seconds >= 1)
        {
            seconds = 1;
            time = 0.0f;
        }
        else
        {
            seconds = 0;
        }

        return seconds;
    }
}
