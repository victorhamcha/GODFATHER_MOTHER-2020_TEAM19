using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2;
    private int dps=5;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += -transform.right * speed * Time.fixedDeltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<TransController>().health -= dps;
            Destroy(this.gameObject);
        }
    }
}
