using UnityEngine;

public static class Utils
{
    public static Vector3 ReadyFirePosition(Vector3 position)
    {
        Vector3 tempPosition = position;
        if (position.x < 0)
        {
            tempPosition.x += 1.3f;
        }
        else
        {
            tempPosition.x -= 1f;
        }

        return tempPosition;
    }

    public enum HumanState
    {
        immutable, isWalking, isPreparingToShoot, isShooting, isbackingToCover
    }

    public enum GameState
    {
        isContinuing, win, lose
    }
}
