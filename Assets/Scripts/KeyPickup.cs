using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Husk at tilføje TextMeshPro support

public class KeyPickup : MonoBehaviour
{
    public GameObject vinderTekst; 
    public float forsinkelse; 
    public AudioClip vinderLyd; 
    private AudioSource lydAfspiller;

    void Start()
    {
        if (vinderTekst != null)
            vinderTekst.SetActive(false); 

        lydAfspiller = GetComponent<AudioSource>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (vinderTekst != null)
                vinderTekst.SetActive(true);

            if (vinderLyd != null && lydAfspiller != null)
                lydAfspiller.PlayOneShot(vinderLyd);

            InventoryManager.instance.AddScore (1);

            Invoke("SkiftScene", forsinkelse);
        }
    }

    void SkiftScene()
    {
        SceneManager.LoadScene("QuizGame");
    }
}



