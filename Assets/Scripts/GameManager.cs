using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerObject;
    
    [SerializeField]
    GameObject[] enemyObjects;

    [SerializeField]
    Text playerHealthText;

    [SerializeField]
    Text enemyHealthText;

    void Update()
    {
        if (GameStateControl() == Utils.GameState.win)
            SceneManager.LoadScene(Utils.Scenes.WinUI);
        else if (GameStateControl() == Utils.GameState.lose)
            SceneManager.LoadScene(Utils.Scenes.LoseUI);

        UIControl();
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

    void UIControl()
    {
        if (playerObject.GetComponent<ILivingCreature>().Health >= 0)
            playerHealthText.text = "Can: "
                + playerObject.GetComponent<ILivingCreature>().Health;

        if (enemyObjects[playerObject
                .GetComponent<Player>().EnemyIndex]
                .GetComponent<ILivingCreature>().Health >= 0)
            enemyHealthText.text = "Düşman Canı: "
                + enemyObjects[playerObject.GetComponent<Player>().EnemyIndex]
                    .GetComponent<ILivingCreature>().Health;
    } 

    bool IsDeadEnemies()
    {
        int numberOfDead = 0;

        foreach (GameObject enemyObject in enemyObjects)
        {
            if (enemyObject.GetComponent<Enemy>().IsDead)
                numberOfDead++;
        }
        return numberOfDead == 2;
    }
}
