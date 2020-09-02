﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2;
    void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.fixedDeltaTime;
    }
}
