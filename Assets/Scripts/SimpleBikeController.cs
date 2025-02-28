
using UnityEngine;

public class SimpleBikeController : MonoBehaviour
{
    public GameObject player;  // Spilleren
    public Transform sitPosition;  // Hvor spilleren skal sidde på cyklen
    private bool isPlayerOnBike = false;

    // Kaldes når en collider træder ind i triggerområdet
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Sørg for, at spilleren har tagget 'Player'
        {
            // Placer spilleren på cyklen og deaktiver fysikken (IsKinematic)
            PlacePlayerOnBike();
        }
    }

    // Funktion til at placere spilleren på cyklen
    void PlacePlayerOnBike()
    {
        Debug.Log("Player is now on the bike");

        // Flyt spilleren til cyklens SitPosition
        player.transform.position = sitPosition.position;
        player.transform.rotation = sitPosition.rotation;

        // Gør spilleren til et barn af cyklen, så de følger cyklen
        player.transform.parent = sitPosition;

        // Deaktiver spillerens Rigidbody fysik (IsKinematic = true)
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.isKinematic = true;
        }

        // Markér spilleren som værende på cyklen
        isPlayerOnBike = true;
    }

    // Hvis spilleren forlader cyklen, fjernes de fra cyklen og får fysikken tilbage
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Spilleren hopper af cyklen
            RemovePlayerFromBike();
        }
    }

    // Funktion til at fjerne spilleren fra cyklen
    void RemovePlayerFromBike()
    {
        Debug.Log("Player is off the bike");

        // Fjern spilleren som barn af cyklen
        player.transform.parent = null;

        // Aktiver spillerens Rigidbody fysik
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.isKinematic = false;
        }

        // Flyt spilleren lidt væk fra cyklen (juster gerne positionen)
        player.transform.position = new Vector3(0, 1, 0);  // Juster denne position
    }
}