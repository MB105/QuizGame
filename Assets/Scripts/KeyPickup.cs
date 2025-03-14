using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Husk at tilføje TextMeshPro support

public class KeyPickup : MonoBehaviour
{
    public GameObject vinderTekst; // UI tekst der viser "Du har vundet!"
    public float forsinkelse = 2f; // Tid før sceneskift
    public AudioClip vinderLyd; // Lyd når nøglen bliver samlet
    private AudioSource lydAfspiller;

    void Start()
    {
        if (vinderTekst != null)
            vinderTekst.SetActive(false); // Skjuler beskeden fra start

        lydAfspiller = GetComponent<AudioSource>(); // Henter AudioSource
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("✅ Player har samlet en nøgle!");

            // Vis vinderbesked
            if (vinderTekst != null)
                vinderTekst.SetActive(true);

            // Spil lyd
            if (vinderLyd != null && lydAfspiller != null)
                lydAfspiller.PlayOneShot(vinderLyd);

            InventoryManager.instance.AddScore (1);

            // Start forsinkelse før sceneskift
            Invoke("SkiftScene", forsinkelse);
        }
    }

    void SkiftScene()
    {
        SceneManager.LoadScene("QuizGame");
    }
}



