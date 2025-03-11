using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public AudioSource deathSound; // Reference til AudioSource

    void Start()
    {
        if (deathSound == null)
        {
            deathSound = GetComponent<AudioSource>(); // Finder AudioSource på Player
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathZone"))
        {
            Debug.Log("Dødszone ramt!");
            deathSound.Play(); // Afspil død-lyden
            Invoke("Respawn", 1f); // Respawn efter 1 sekund
        }
    }

    public void Respawn()
    {
        transform.position = new Vector3(724, 153, 1288); // Udskift med din startposition
    }
}
