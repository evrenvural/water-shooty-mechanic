using System;
using UnityEngine;

public static class Utils
{
    public static Vector3 HeadOfHuman(Vector3 position)
    {
        Vector3 tempPosition = position;
        tempPosition.y += 0.5f;
        return tempPosition;
    }
}
