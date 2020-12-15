using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PulpoScript : MonoBehaviour
{
    public NavMeshAgent pulpo;
    public Transform player;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Te agarro el pulpo");
            SceneManager.LoadScene("GameOver");
            

        }

    }

    void Update()
    {
        pulpo.SetDestination(player.position); 
    }
}
