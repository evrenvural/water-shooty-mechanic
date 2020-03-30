using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Address : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
        { 
            player.GetComponent<Player>().IsMoving = false;
            player.GetComponent<Player>().addressIndex++;
        }
    }
}
