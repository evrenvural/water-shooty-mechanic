using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerObject;
    
    [SerializeField]
    GameObject[] enemyObjects;

    void Update()
    {
        if (GameStateControl() == Utils.GameState.win)
            Debug.Log("KAZANDI");
        else if (GameStateControl() == Utils.GameState.lose)
            Debug.Log("YENİLDİ");
    }

    Utils.GameState GameStateControl()
    {
        if (playerObject.GetComponent<Player>().IsDead)
            return Utils.GameState.lose;
        else if (IsDeadEnemies())
            return Utils.GameState.win;
        else
            return Utils.GameState.isContinuing;
    }

    bool IsDeadEnemies()
    {
        int numberOfDead = 0;
        foreach (GameObject enemyObject in enemyObjects)
        {
            if (enemyObject.GetComponent<Enemy>().IsDead)
                numberOfDead++;
        }
        return numberOfDead == enemyObjects.Length;
    }
}
