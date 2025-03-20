using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource backgroundMusic; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            backgroundMusic.Pause();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            backgroundMusic.Play(); 
        }
    }
}

