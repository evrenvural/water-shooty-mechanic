using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject[] addresses;

    [SerializeField]
    float speed;

    public bool IsMoving { get; set; } = true;
    public int addressIndex { get; set; } = 0;

    void Update()
    {
        Fire();    
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsMoving = true;
            Debug.Log(IsMoving);
        }
    }

    private void Move()
    {
        if (IsMoving)
        {
            Vector3 tempPosition = transform.position;

            // For walls on right
            if(addressIndex % 2 == 0)
            {
                if (transform.position.x < addresses[addressIndex].transform.position.x)
                    tempPosition.x += speed;
                if (transform.position.z < addresses[addressIndex].transform.position.z)
                    tempPosition.z += speed;
            }
            // For walls on left
            else
            {
                if (transform.position.x > addresses[addressIndex].transform.position.x)
                    tempPosition.x -= speed;
                if (transform.position.z < addresses[addressIndex].transform.position.z)
                    tempPosition.z += speed;
            }

            transform.position = tempPosition;
        }
    }
}
