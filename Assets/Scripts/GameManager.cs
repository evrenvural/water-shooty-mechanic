using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerObject;
    [SerializeField]
    GameObject enemyObject;

    Player player;
    Enemy enemy;


    void Start()
    {
        InitVariables();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitVariables()
    {
        player = playerObject.GetComponent<Player>();
        enemy = enemyObject.GetComponent<Enemy>();
    }
}
