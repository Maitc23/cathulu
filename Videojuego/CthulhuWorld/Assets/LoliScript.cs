﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoliScript : MonoBehaviour
{
    public float speed = 5f;
    public float RotateSpeed = 1000f;

    void Start()
    {
 
    }

    void Update()
    {
        // Rotación 
        if (Input.GetKey(KeyCode.J))
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime, 1);
        else if (Input.GetKey(KeyCode.K))
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime, 1);

        // Movimiento
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(horizontal, 0, vertical);
    }
}
