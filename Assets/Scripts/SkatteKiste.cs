using UnityEngine;

public class SkatteKiste : MonoBehaviour
{
    public Animator kisteAnimator; // Animator til kisten
    public AudioClip aabneLyd; // Lyd ved åbning
    public AudioClip vinderLyd;
    private AudioSource lydAfspiller;
    private bool erAabnet = false;

    void Start()
    {
        lydAfspiller = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
{
    Debug.Log("🔍 Kollision registreret med: " + collision.gameObject.name);

    if (collision.gameObject.CompareTag("Player"))
    {
        Debug.Log("✅ Spilleren ramte kisten!");
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
        kisteAnimator.SetTrigger("Aabn"); // Sørg for, at triggeren hedder "Aabn"
        
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



