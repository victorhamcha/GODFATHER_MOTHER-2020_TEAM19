using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private int speed = 2;
    private int dps= 30;
    public Transform roofPosition;

    private bool goal;
    private bool ground;
    private float cooldown = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        roofPosition = GameObject.FindGameObjectWithTag("Roof").transform;
        this.transform.localPosition = GameObject.FindGameObjectWithTag("Enemy").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position == roofPosition.position && !goal)
        {
            goal = true;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if(this.transform.position != roofPosition.position && !goal)
        {
            this.transform.localPosition = Vector2.MoveTowards(transform.position, roofPosition.position, 1.5f*speed*Time.deltaTime);
        }

        if (goal && !ground)
        {
            this.transform.localPosition = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y - speed * Time.deltaTime);
        }
        if (ground)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Text"));
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
            Debug.Log("Touch");
            ground = true;
        }
    }
}
