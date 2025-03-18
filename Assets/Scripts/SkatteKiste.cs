using UnityEngine;

public class SkatteKiste : MonoBehaviour
{
    public Animator kisteAnimator; 
    public AudioClip aabneLyd; 
    public AudioClip vinderLyd; 
    private AudioSource lydAfspiller;
    private bool erAabnet = false;

    void Start()
    {
        lydAfspiller = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (!erAabnet)
            {
                ForsøgAtÅbne();
            }
        }
    }

    void ForsøgAtÅbne()
    {
        if (InventoryManager.instance.GetKeyCount() > 1)
        {
            AabnKiste();
        }
    }

    void AabnKiste()
    {
        erAabnet = true;
        kisteAnimator.SetTrigger("Aabn"); 

        if (aabneLyd != null) lydAfspiller.PlayOneShot(aabneLyd);

        if (vinderLyd != null) Invoke(nameof(SpilVinderLyd), 2.0f);

    }

    void SpilVinderLyd()
    {
        lydAfspiller.PlayOneShot(vinderLyd);
    }
}



