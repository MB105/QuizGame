using UnityEngine;

public class SkatteKiste : MonoBehaviour
{
    public Animator kisteAnimator; // Animator til kisten
    public AudioClip aabneLyd; // Lyd ved åbning
    public AudioClip vinderLyd; // Vinderlyd
    private AudioSource lydAfspiller;
    private bool erAabnet = false;

    void Start()
    {
        lydAfspiller = GetComponent<AudioSource>();
    }

    // Skiftet til OnTriggerEnter
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("🔍 Trigger registreret med: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("✅ Spilleren gik ind i kistens trigger-zone!");
            if (!erAabnet)
            {
                ForsøgAtÅbne();
            }
        }
    }

    void ForsøgAtÅbne()
    {
        if (InventoryManager.instance.GetKeyCount() > 0)
        {
            AabnKiste();
        }
        else
        {
            Debug.Log("🚪 Du har ikke nok nøgler til at åbne skatten!");
        }
    }

    void AabnKiste()
    {
        erAabnet = true;
        kisteAnimator.SetTrigger("Aabn"); // Sørg for, at triggeren i Animator hedder "Aabn"

        // Afspil første lyd med det samme
        if (aabneLyd != null) lydAfspiller.PlayOneShot(aabneLyd);

        // Afspil den anden lyd efter 2 sekunder
        if (vinderLyd != null) Invoke(nameof(SpilVinderLyd), 2.0f);

        Debug.Log("🎉 SkatteKisten er åbnet!");
    }

    void SpilVinderLyd()
    {
        lydAfspiller.PlayOneShot(vinderLyd);
    }
}



