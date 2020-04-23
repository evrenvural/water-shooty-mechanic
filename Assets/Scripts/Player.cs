﻿using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, ILivingCreature
{
    [SerializeField]
    GameObject[] enemies;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float waitForGun;

    [SerializeField]
    float speed;

    [SerializeField]
    float bulletSpeed;

    public Utils.HumanState State { get; set; } = Utils.HumanState.isWalking;

    public bool IsDead { get; set; } = false;         

    public int EnemyIndex { get; set; } = 0;
    
    public int Health { get; set; } = 15;

    bool wait = true;

    void Update()
    {
        Fire();
        IsReadyForFireControl();
        IsDeadControl();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "BulletEnemy")
        {
            Health--;
            Destroy(collider.gameObject);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitForGun);
        wait = true;
    }

    private void Fire()
    {
        if (State != Utils.HumanState.isWalking)
        {
            if (Input.GetMouseButton(0))
            {
                if (State == Utils.HumanState.isShooting)
                {
                    if (wait)
                    {
                        Instantiate(bullet, transform.position, Quaternion.identity, transform)
                                                .GetComponent<Rigidbody>()
                                                .AddForce((enemies[EnemyIndex].transform.position
                                                - Utils.ReadyFirePosition(enemies[EnemyIndex - 1].transform.position))
                                                * bulletSpeed);
                        wait = false;
                        StartCoroutine(Wait());
                    }
                }
                if (State != Utils.HumanState.isShooting)
                    State = Utils.HumanState.isPreparingToShoot;
            }
            if (Input.GetMouseButtonUp(0))
            {
                State = Utils.HumanState.isbackingToCover;
            }
        }
    }

    private void Move()
    {
        Vector3 tempPosition = transform.position;

        switch (State)
        {
            case Utils.HumanState.isWalking:
                // For walls on right
                if (EnemyIndex % 2 == 0)
                {
                    if (transform.position.x < enemies[EnemyIndex].transform.position.x)
                        tempPosition.x += speed;
                    if (transform.position.z < enemies[EnemyIndex].transform.position.z)
                        tempPosition.z += speed;
                }
                // For walls on left
                else
                {
                    if (transform.position.x > enemies[EnemyIndex].transform.position.x)
                        tempPosition.x -= speed;
                    if (transform.position.z < enemies[EnemyIndex].transform.position.z)
                        tempPosition.z += speed;
                }
                break;
            case Utils.HumanState.isPreparingToShoot:
                // For walls on right
                if (EnemyIndex % 2 == 1)
                {
                    if (tempPosition.x > Utils.ReadyFirePosition(enemies[EnemyIndex - 1].transform.position).x)
                        tempPosition.x -= speed;
                }
                // For walls on left
                else
                {
                    if (tempPosition.x < Utils.ReadyFirePosition(enemies[EnemyIndex - 1].transform.position).x)
                        tempPosition.x += speed;
                }
                break;
            case Utils.HumanState.isbackingToCover:
                // For walls on right
                if (EnemyIndex % 2 == 1)
                {
                    if (tempPosition.x <= enemies[EnemyIndex - 1].transform.position.x)
                        tempPosition.x += speed;
                }
                // For walls on left
                else
                {
                    if (tempPosition.x >= enemies[EnemyIndex - 1].transform.position.x)
                        tempPosition.x -= speed;
                }
                break;
        }

        transform.position = tempPosition;
    }

    private void IsReadyForFireControl()
    {
        if (State == Utils.HumanState.isPreparingToShoot)
        {
            // For walls on right
            if (EnemyIndex % 2 == 0)
            {
                if (transform.position.x >= Utils.ReadyFirePosition(enemies[EnemyIndex - 1].transform.position).x)
                    State = Utils.HumanState.isShooting;
            }
            // For walls on left
            else
            {
                if (transform.position.x <= Utils.ReadyFirePosition(enemies[EnemyIndex - 1].transform.position).x)
                    State = Utils.HumanState.isShooting;
            }
        }
    }

    private void IsDeadControl()
    {
        IsDead = Health <= 0;
    }
}
