using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    // Denne funktion bliver kaldt, når kollisionen finder sted
    void OnCollisionEnter(Collision collision)
    {
        // Udskriv et message til konsollen
        Debug.Log("Kollision med: " + collision.gameObject.name);

        // Hvis objektet, der kolliderer, har tagget "Player", gør noget specielt
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Spilleren ramte boksen!");
            // Her kan du tilføje flere handlinger, som skal udføres når spilleren rammer boksen
        }
    }
}

