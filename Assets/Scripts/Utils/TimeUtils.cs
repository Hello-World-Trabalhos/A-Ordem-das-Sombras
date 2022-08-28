using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUtils
{
    public float GetGameTimeInMilliseconds()
    {
        return Time.time * 1000;
    }

    public float GetTimeInMilliseconds(float number)
    {
        return number * 1000;
    }
}
