using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            player.GetComponent<Player>().IsMoving = false;
            player.GetComponent<Player>().EnemyIndex++;
        }
    }
}
