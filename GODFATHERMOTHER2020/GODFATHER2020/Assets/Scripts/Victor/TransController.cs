using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransController : MonoBehaviour
{
   [Header("Mouvement")]
    public bool ground = true;
    public float jumpForce = 10f;
    public float speed = 0.1f;
    private bool isMouving = false;
    private bool megaJump = false;
    private float megaJumpTimer = 0.8f;
    [SerializeField] private float megaJumpCoulDown = 0.8f;
    private Rigidbody2D rb;
    [SerializeField]private float megaJumpForce;

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
    private float timerBlock = 2f;
    public Transform lifeBar;


    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        megaJumpTimer = megaJumpCoulDown;
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") < -0.3)
        {
            transform.Translate(-speed, 0, 0);
            //mySpriteRenderer.flipX = true;
            isMouving = true;
        }
        else if (Input.GetAxis("Horizontal") > 0.3)
        {
            transform.Translate(speed, 0, 0);
            //mySpriteRenderer.flipX = false;
            isMouving = true;
        }
        else
        {
            isMouving = false;
        }

        if (!ground)
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Joystick1Button0) && ground)
        {
            ground = false;
            Debug.Log("Jump");
            block=false;
        }
        else if(Input.GetKey(KeyCode.Joystick1Button0) &&megaJumpTimer>0&&!megaJump)
        {
            megaJumpTimer -= Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Joystick1Button0) && megaJumpTimer < 0 && !megaJump)
        {
            megaJump = true;
            rb.velocity = Vector2.up * megaJumpForce;
        }



     

      if(Input.GetKeyDown(KeyCode.Joystick1Button5) &&!isAttacking)
        {
            block = true;
            if(timerBlock<=0)
            {
                timerBlock = 2f;
            }
        }
      if(block && timerBlock>0)
       {
            timerBlock -= Time.deltaTime;
       }
     
      else
      {
            block = false;
      }
        if (!block&&timerBlock<2)
        {
            timerBlock += Time.deltaTime / 2;
        }
        else if (!block&&timerBlock>2)
        {
            timerBlock = 2;
        }

      if (Input.GetKeyUp(KeyCode.Joystick1Button5))
      {
            block = false;
      }

        //Attack Mele
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && !isAttacking&&!isMouving)
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
            if (block)
            {
                block = false;
            }
            //pour trans
            hairCollider.SetActive(false);

        }
      



        //Attack Bullet
        if (Input.GetKey(KeyCode.Joystick1Button2)&&timerSound<=0)
        {
            timerSound = couldownSound;
            if(block)
            {
                block = false;
            }
            Instantiate(bulletSound, visor.position, Quaternion.identity);
        }
        else if(timerSound>0)
        {
            timerSound -= Time.deltaTime;
        }




        //GAME OVER//
        

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
        if (health < 0)
            health = 0;
        lifeBar.localScale = new Vector2(health/100f, lifeBar.localScale.y);

        if (health <= 0)
        {
            Time.timeScale = 0;
            gameManager.gameOverScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
            megaJump = false;

            megaJumpTimer = megaJumpCoulDown;
            //myAnimator.SetBool("isJumping", false);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage(5);

            //myAnimator.SetBool("isJumping", false);
        }
    }
}
