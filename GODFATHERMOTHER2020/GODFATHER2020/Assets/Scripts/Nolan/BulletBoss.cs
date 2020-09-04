using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Line Shoot")]
    public float speed = 2;

    [Header("Sinusoidal shoot")]
    private float magnitude = 0.1f;
    private float frequency = 10f;


    private int movement;
    private int dps=5;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossManager>().phase == BossManager.Phase.PhaseOne)
        {
            movement = 0;
        }
        else if (GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossManager>().phase == BossManager.Phase.PhaseTwo)
        {
            movement = 1;
        }
        else
        {
            movement = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movement==0)
        {
            transform.position += -transform.right * speed * Time.fixedDeltaTime;
        }
        else if(movement==1)
        {
            transform.position += -transform.right * speed * Time.fixedDeltaTime + transform.up*Mathf.Sin(Time.time*frequency)*magnitude;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<TransController>().Damage(dps);
            Destroy(this.gameObject);
        }
    }
}
