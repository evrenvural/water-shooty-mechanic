using UnityEngine;

public class Root : MonoBehaviour
{
    void OnTriggerExit(Collider collider)
    {
        Destroy(collider.gameObject);
    }
}
