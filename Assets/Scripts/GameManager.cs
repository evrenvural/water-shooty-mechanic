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

    [SerializeField]
    Text numberOfDeathText;

    [SerializeField]
    Text umbrellaCounterText;

    Player player;

    void Start()
    {
        player = playerObject.GetComponent<Player>();
    }

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
        if (player.IsDead)
            return Utils.GameState.lose;
        else if (IsDeadEnemies())
            return Utils.GameState.win;
        else
            return Utils.GameState.isContinuing;
    }

    void UIControl()
    {
        // Player Health
        if (playerObject.GetComponent<ILivingCreature>().Health >= 0)
            playerHealthText.text = "Can: "
                + playerObject.GetComponent<ILivingCreature>().Health;

        // Enemy Health
        if (enemyObjects[playerObject
                .GetComponent<Player>().EnemyIndex]
                .GetComponent<ILivingCreature>().Health >= 0)
            enemyHealthText.text = "Düşman Canı: "
                + enemyObjects[player.EnemyIndex]
                    .GetComponent<ILivingCreature>().Health;

        // Number Of Deaths
        int numberOfDeath = 0;
        foreach (GameObject enemyObject in enemyObjects)
        {
            if (enemyObject.GetComponent<Enemy>().IsDead)
            {
                numberOfDeath++;
            }
        }
        numberOfDeathText.text = "Ölü Düşman Sayısı: " + numberOfDeath;

        // Umbrella Counter
        if (player.State == Utils.HumanState.isWalking)
            umbrellaCounterText.text = "";
        else
            umbrellaCounterText.text = "Şemsiye Sayacı: " + player.SecondsForUmbrella + "/" + player.OpenUmbrellaSeconds;

    }

    bool IsDeadEnemies()
    {
        int numberOfDeath = 0;
        foreach (GameObject enemyObject in enemyObjects)
        {
            if (enemyObject.GetComponent<Enemy>().IsDead)
                numberOfDeath++;
        }
        return numberOfDeath == 2;
    }
}
