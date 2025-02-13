using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); // Henter Animator-komponenten på døren
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Tjekker om det er spilleren, der træder ind
        {
            animator.SetTrigger("Open"); // Starter åbne-animationen
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Tjekker om spilleren forlader zonen
        {
            animator.SetTrigger("Close"); // Starter lukke-animationen
        }
    }
}

