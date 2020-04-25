using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bullet" || collider.tag == "BulletEnemy")
            Destroy(collider.gameObject);
    }
}
