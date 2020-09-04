using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hairs : MonoBehaviour
{
    public BossManager boss;
    public int dmg;
    bool canTouch=true;
    float timerOftouching;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(!canTouch && timerOftouching<0.3f)
        {
            timerOftouching += Time.deltaTime;
        }
        else if(!canTouch&&timerOftouching>0.3f)
        {
            timerOftouching = 0;
            canTouch = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       if(collision.gameObject.tag=="Enemy"&&canTouch)
       {
            boss.hp -= dmg;
            Debug.Log(boss.hp);
            canTouch = false;
       }
    }


}
