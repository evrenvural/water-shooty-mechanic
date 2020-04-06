using UnityEngine;

public class Wall : MonoBehaviour
{
    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Bullet" || collider.tag == "BulletEnemy")
            Destroy(collider.gameObject);
    }
}
