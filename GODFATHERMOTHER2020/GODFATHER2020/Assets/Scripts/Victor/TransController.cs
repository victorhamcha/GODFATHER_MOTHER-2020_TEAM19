using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransController : MonoBehaviour
{
   [Header("Mouvement")]
    public bool ground = true;
    public float jumpForce = 10f;
    public float speed = 0.1f;
    [Header("Mele Attack")]
    public float couldownMeleAttack = 0.3f;
    private float timeMeleAttack = 0;
    private bool isAttacking;
    //pour trans
    public GameObject hairCollider;
    
    [Header("Bullet Attack")]
    public float couldownSound = 0.1f;
    private float timerSound = 0;
    public GameObject bulletSound;
    public Transform visor;
    [Header("Health")]
    public float health = 100f;
    private bool block=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") < -0.3)
        {
            transform.Translate(-speed, 0, 0);
            //mySpriteRenderer.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0.3)
        {
            transform.Translate(speed, 0, 0);
            //mySpriteRenderer.flipX = false;
        }

        if (!ground)
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            ground = false;
            Debug.Log("Jump");
        }

        if (Input.GetKeyDown(KeyCode.C) && ground)
        {
            ground = false;
            Debug.Log("Jump");
        }

      

        //Attack Mele
        if (Input.GetKey(KeyCode.B) && !isAttacking)
        {
            isAttacking = true;
            //pour trans
            hairCollider.SetActive(true);
        }
        else if(isAttacking&&timeMeleAttack>0)
        {
            timeMeleAttack -= Time.deltaTime;
        }
        else if(isAttacking && timeMeleAttack <= 0)
        {
            timeMeleAttack = couldownMeleAttack;
            isAttacking = false;
            //pour trans
            hairCollider.SetActive(false);

        }
      



        //Attack Bullet
        if (Input.GetKey(KeyCode.A)&&timerSound<=0)
        {
            timerSound = couldownSound;
            Instantiate(bulletSound, visor.position, Quaternion.identity);
        }
        else if(timerSound>0)
        {
            timerSound -= Time.deltaTime;
        }

    }

    public void Damage(float dmg)
    {
        if(block)
        {
            health -= dmg / 2;
            
        }
        else
        {
            health -= dmg;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
           
            //myAnimator.SetBool("isJumping", false);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage(5);

            //myAnimator.SetBool("isJumping", false);
        }
    }
}
