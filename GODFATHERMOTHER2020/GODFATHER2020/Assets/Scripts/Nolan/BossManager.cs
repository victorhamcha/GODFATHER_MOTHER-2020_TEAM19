using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [Header("Stats")]
    public int hp;
    public int dps;
    protected enum State { Melee, Distance};
    protected State etat;

    [Header("Distance")]
    public Transform[] firePoint;
    public GameObject bullet;
    private int rand;
    private float cooldownBullet = 0.0f;
    private bool shoot;



    [Header("Melee")]
    public Transform target;
    private float cooldown=0.0f;
    private bool attacking;
    private bool canHit;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
        if (canHit)
        {
            etat = State.Melee;
        }
        else
        {
            etat = State.Distance;
        }
        Attack();

        if (attacking)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                attacking = false;
            }
        }
        if (shoot)
        {
            cooldownBullet -= Time.deltaTime;
            if (cooldownBullet <= 0)
            {
                shoot = false;
            }
        }
    }

    public void Attack()
    {
        if (etat == State.Melee)
        {
            if (!attacking)
            {
                target.gameObject.GetComponent<TransController>().health -= dps;
                cooldown = 5.0f;
                attacking = true;
            }
        }
        else if(!shoot)
        {
            shoot = true;
            cooldownBullet = 3.0f;
            rand=Random.Range(0, firePoint.Length);
            GameObject bulletGameObject = (GameObject)Instantiate(bullet, firePoint[rand].position, firePoint[rand].rotation);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canHit = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canHit = false;
        }
    }
}
