using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canJump;
    public bool ground=true;
    private float jump = 10f;
    public float speed = 0.1f;
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

        if (Input.GetKeyDown("joystick button 1") && ground)
        {
            canJump = true;
            //myAnimator.SetBool("isJumping", true);
            ground = false;
            Debug.Log("Jump");
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
            Debug.Log("ok");
            //myAnimator.SetBool("isJumping", false);
        }
    }
}
