using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemy;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float speed;

    [SerializeField]
    float bulletSpeed;

    public bool IsMoving { get; set; } = true;

    public int EnemyIndex { get; set; } = 0;

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
            GameObject bulletObject = Instantiate(bullet, transform.position, Quaternion.identity, transform);
            bulletObject
                .GetComponent<Rigidbody>()
                .AddForce((Utils.HeadOfHuman(enemy[EnemyIndex].transform.position) - transform.position) * bulletSpeed);
        }
    }

    private void Move()
    {
        if (IsMoving)
        {
            Vector3 tempPosition = transform.position;

            // For walls on right
            if (EnemyIndex % 2 == 0)
            {
                if (transform.position.x < enemy[EnemyIndex].transform.position.x)
                    tempPosition.x += speed;
                if (transform.position.z < enemy[EnemyIndex].transform.position.z)
                    tempPosition.z += speed;
            }
            // For walls on left
            else
            {
                if (transform.position.x > enemy[EnemyIndex].transform.position.x)
                    tempPosition.x -= speed;
                if (transform.position.z < enemy[EnemyIndex].transform.position.z)
                    tempPosition.z += speed;
            }

            transform.position = tempPosition;
        }
    }
}
