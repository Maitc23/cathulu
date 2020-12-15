using UnityEngine;
using UnityEngine.AI;

public class PulpoScript : MonoBehaviour
{
    public NavMeshAgent pulpo;
    public Transform player;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Te agarro el pulpo");
        }
    }

    void Update()
    {
        pulpo.SetDestination(player.position); 
    }
}
