using UnityEngine;
using UnityEngine.UI;

public class LoliScript : MonoBehaviour
{
    public int legendarios = 0;
    public bool cubeOnGround = false;
    public Rigidbody rb;
    public float reloj = 60f;
    public Text timer_ui;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float speed = 2f;
        // Rotación 
        if (Input.GetKey(KeyCode.J))
            transform.Rotate(-Vector3.up * 25 * Time.deltaTime, 1);
        else if (Input.GetKey(KeyCode.K))
            transform.Rotate(Vector3.up * 25 * Time.deltaTime, 1);
        if (Input.GetKeyDown(KeyCode.Space) && cubeOnGround)
        {
            rb.AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
            cubeOnGround = false;
        }

        // Movimiento
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(horizontal, 0, vertical);

        // Timer
        reloj -= Time.deltaTime; // Resta 1 cada segundo 
        timer_ui.text = reloj.ToString("f0"); // Lo muestra en la ui

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

        if (collision.collider.CompareTag("Floor"))
        {
            cubeOnGround = true;
        }

    }
 }
