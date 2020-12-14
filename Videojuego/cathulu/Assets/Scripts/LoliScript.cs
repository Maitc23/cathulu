using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoliScript : MonoBehaviour
{
    public float speed = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        // Movimiento
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(horizontal, 0, vertical);

    }
}
