using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Letter : MonoBehaviour
{
    private int speed = 2;
    private float cooldown = 2.0f;
    private int dps = 10;
    private bool ground;

    // Update is called once per frame
    void Update()
    {
        if (!ground)
        {
            this.transform.localPosition = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y - speed * Time.deltaTime);
        }

        if (ground)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<TransController>().Damage(dps);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
        }
    }
}
