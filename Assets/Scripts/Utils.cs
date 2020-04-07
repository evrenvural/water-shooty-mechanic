using UnityEngine;

public static class Utils
{
    public enum HumanState
    {
        immutable, isWalking, isPreparingToShoot, isShooting, isbackingToCover
    }

    public enum GameState
    {
        isContinuing, win, lose
    }

    public static class Scenes {
        public static string Game { get; private set; } = "Game";
        public static string WinUI { get; private set; } = "WinUI";
        public static string LoseUI { get; private set; } = "LoseUI";
    }

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
}
