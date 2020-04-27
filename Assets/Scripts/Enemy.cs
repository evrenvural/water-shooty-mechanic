using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, ILivingCreature
{
    [SerializeField]
    GameObject playerObject;

    [SerializeField]
    float waitForGun;

    [SerializeField]
    float bulletSpeed;

    [SerializeField]
    GameObject bullet;
    
    Player player;
    bool playerTriggered = false;
    bool wait = true;
    
    public int Health { get; set; } = 14;
    public bool IsDead { get; set; } = false;

    void Start()
    {
        player = playerObject.GetComponent<Player>();
    }

    void Update()
    {
        Fire();
        IsDeadControl();
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            player.State = Utils.HumanState.immutable;
            if (!playerTriggered)
            {
                player.EnemyIndex++;
                playerTriggered = true;
            }
        }
        else if (collider.tag == "Bullet" && GetComponent<Renderer>().enabled)
        {
            if (IsDead)
            {
                GameObject.FindGameObjectWithTag("Visual").SetActive(false);
                GetComponent<Renderer>().enabled = false;

                player.State = Utils.HumanState.isWalking;
            }

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
        if (!IsDead && GetComponent<Renderer>().enabled)
        {
            if (player.State == Utils.HumanState.isShooting)
            {
                if (wait)
                {
                    Instantiate(bullet, Utils.FireAimPosition(transform.position), Quaternion.identity, transform)
                        .GetComponent<Rigidbody>().AddForce(
                        (playerObject.transform.position - transform.position)
                        * bulletSpeed);
                    
                    wait = false;
                    
                    StartCoroutine(Wait());
                }
            }
        }
    }

    private void IsDeadControl()
    {
        IsDead = Health <= 0;
    }
}
