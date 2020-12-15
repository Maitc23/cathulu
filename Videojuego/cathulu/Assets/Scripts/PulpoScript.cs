using UnityEngine;

public class PulpoScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Te agarro el pulpo");
        }
    }
}
