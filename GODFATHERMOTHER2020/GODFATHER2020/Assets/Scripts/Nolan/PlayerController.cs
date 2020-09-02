using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canJump;
    public bool ground=true;
    private float jump = 5f;
    public float speed = 0.1f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        if (Input.GetKeyDown("joystick button 1") && ground)
        {
            canJump = true;
            //myAnimator.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jump;
            ground = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ground)
        {
            canJump = false;
            transform.Translate(Vector3.up * jump * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
            //myAnimator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
            ground = false;
        }
    }
}
