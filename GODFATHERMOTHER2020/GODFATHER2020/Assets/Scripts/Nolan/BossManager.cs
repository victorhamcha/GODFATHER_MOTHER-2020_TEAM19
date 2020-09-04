using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    [Header("Stats")]
    public int hp;
    public int dps;
    private int maxHp;
    protected enum State { Melee, Distance };
    protected State etat;
    public enum Phase { PhaseOne, PhaseTwo, PhaseThird, PhaseFour };
    public Phase phase;

    [Header("Distance")]
    public Transform[] firePoint;
    public GameObject bullet;
    private int rand;
    private float cooldownBullet = 0.0f;
    private bool shoot;
    private bool spawnPoint;

    [Header("Melee")]
    public GameObject target;
    private float cooldown = 0.0f;
    private bool attacking;
    private bool canHit;

    public GameObject attackLetter;
    public Slider health;

    private float cooldown_scream = 0.0f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        maxHp = hp;
        phase = Phase.PhaseOne;
        target = GameObject.FindGameObjectWithTag("Player");
        health.maxValue = maxHp;
        health.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        health.value = maxHp - hp;
        if (((float)hp / maxHp) * 100 <= 75 && ((float)hp / maxHp) * 100 > 50 && phase != Phase.PhaseTwo)
        {
            phase = Phase.PhaseTwo;
        }
        else if (((float)hp / maxHp) * 100 <= 50 && ((float)hp / maxHp) * 100 > 25 && phase != Phase.PhaseThird)
        {
            phase = Phase.PhaseThird;
            anim.SetBool("Scream", true);
            cooldown_scream = 3.0f;
            GameObject letterAttack = (GameObject)Instantiate(attackLetter, this.transform.position, this.transform.rotation);
        }
        else if (((float)hp / maxHp) * 100 <= 25 && phase != Phase.PhaseFour)
        {
            phase = Phase.PhaseFour;
            anim.SetBool("Scream", true);
            cooldown_scream = 3.0f;
            GameObject letterAttack = (GameObject)Instantiate(attackLetter, this.transform.position, this.transform.rotation);

        }

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

        if (cooldown_scream > 0)
        {
            cooldown_scream -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (etat == State.Melee)
        {
            if (!attacking)
            {
                target.GetComponent<TransController>().health -= dps;
                cooldown = 5.0f;
                anim.SetBool("Shoot", false);
                anim.SetBool("Fight", true);
                attacking = true;
            }
        }
        else if (!shoot)
        {
            anim.SetBool("Fight", false);
            shoot = true;
            cooldownBullet = 3.0f;
            if (phase == Phase.PhaseOne || phase == Phase.PhaseTwo)
            {
                rand = Random.Range(0, firePoint.Length);
                GameObject bulletGameObject = (GameObject)Instantiate(bullet, firePoint[rand].position, firePoint[rand].rotation);
            }
            else if (phase == Phase.PhaseThird)
            {
                if (!spawnPoint) { GameObject bulletGameObject = (GameObject)Instantiate(bullet, firePoint[0].position, firePoint[0].rotation); spawnPoint = !spawnPoint; }
                else { GameObject bulletGameObject = (GameObject)Instantiate(bullet, firePoint[2].position, firePoint[2].rotation); spawnPoint = !spawnPoint; }
                cooldownBullet = 1.5f;
            }
            else
            {
                GameObject bulletGameObject = (GameObject)Instantiate(bullet, firePoint[1].position, firePoint[1].rotation);
                GameObject bulletGameObject2 = (GameObject)Instantiate(bullet, firePoint[3].position, firePoint[3].rotation);
            }
            if (cooldown_scream <= 0)
            {
                anim.SetBool("Scream", false);
                anim.SetBool("Shoot", true);
                Debug.Log("Ok mec");
            }

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
