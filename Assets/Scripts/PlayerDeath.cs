using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public AudioSource deathSound; 

    void Start()
    {
        if (deathSound == null)
        {
            deathSound = GetComponent<AudioSource>(); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathZone"))
        {
            deathSound.Play(); 
            Invoke("Respawn", 1f); 
        }
    }

    public void Respawn()
    {
        transform.position = new Vector3(724, 153, 1288); 
    }
}
