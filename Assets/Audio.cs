using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource backgroundMusic; // Drag and drop the background music AudioSource here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure your player has the tag "Player"
        {
            backgroundMusic.Pause(); // Pause the music when entering
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            backgroundMusic.Play(); // Resume the music when exiting
        }
    }
}

