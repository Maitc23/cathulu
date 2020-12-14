using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoliScript : MonoBehaviour
{
    public int legendarios = 0;
    public Rigidbody rb;
    public float speed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Rotación 
        if (Input.GetKey(KeyCode.J))
            transform.Rotate(-Vector3.up * 45 * Time.deltaTime, 1);
        else if (Input.GetKey(KeyCode.K))
            transform.Rotate(Vector3.up * 45 * Time.deltaTime, 1);

        // Movimiento
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(horizontal, 0, vertical);

    }

    void OnCollisionEnter(Collision collision)
    {
        // Al tocar un objeto legendario aumenta el contador
        if (collision.collider.tag == "Legendario")
        {
            Debug.Log("Objeto Legendario!!!");
            legendarios += 1;
            Destroy(collision.gameObject);
        }

        if (collision.collider.tag == "Portal")
        {
            if (legendarios == 5)
            {
                Debug.Log("GG");
            }
            else
            {
                Debug.Log("No posee los 5 objetos legendarios");
            }
        }

    }
 }
