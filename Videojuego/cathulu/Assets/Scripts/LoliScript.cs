using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoliScript : MonoBehaviour
{
    public GameObject SonidoAgarre;
    public int legendarios = 0;
    public bool cubeOnGround = false;
    public Rigidbody rb;
    public float reloj;
    public Text timer_ui;
    public float speed;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        reloj = 20f;
        speed = 2f;
    }

    void Update()
    {
        // Rotación 
        if (Input.GetKey(KeyCode.J))
            transform.Rotate(-Vector3.up * 25 * Time.deltaTime, 1);
        else if (Input.GetKey(KeyCode.K))
            transform.Rotate(Vector3.up * 25 * Time.deltaTime, 1);
        if (Input.GetKeyDown(KeyCode.Space) && cubeOnGround)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            cubeOnGround = false;
        }

        if (Input.GetKeyDown("w") | Input.GetKeyDown("s") | Input.GetKeyDown("a") | Input.GetKeyDown("d")){
            anim.Play("correrAnimation");
        }

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            anim.Play("saltarAnimation");
        }

        // Movimiento
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(horizontal, 0, vertical);

        // Timer
        reloj -= Time.deltaTime; // Resta 1 cada segundo 
        timer_ui.text = reloj.ToString("f0"); // Lo muestra en la ui

        if (reloj <= 0)
        {
            Debug.Log("Se acabo el tiempo");
            SceneManager.LoadScene("Menu");
            // Mensaje de game over aqui 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Al tocar un objeto legendario aumenta el contador
        if (collision.collider.tag == "Legendario")
        {
            Instantiate(SonidoAgarre);
            Debug.Log("Objeto Legendario!!!");
            legendarios += 1;
            reloj += 20f;
            Destroy(collision.gameObject);

        }

        // Detecta la caida del mundo
        if (collision.collider.tag == "Void")
        {
            Debug.Log("Te caiste!!!");
            // Aqui mensaje de Game over
        }

        // Detecta el portal 
        if (collision.collider.tag == "Portal")
        {
            if (legendarios == 5)
            {
                Debug.Log("GG");
                SceneManager.LoadScene("Menu");
                // Mensaje de gg aqui 

            }
            else
            {
                Debug.Log("No posee los 5 objetos legendarios");
            }
        }

        // Detecta la superficie de la isla
        if (collision.collider.CompareTag("Floor"))
        {
            cubeOnGround = true;
        }

    }
 }
