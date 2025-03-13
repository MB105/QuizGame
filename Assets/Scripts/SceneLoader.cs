using UnityEngine;
using UnityEngine.SceneManagement; // Gør det muligt at skifte scene

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad; // Navnet på scenen, der skal loades

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Tjekker om det er spilleren
        {
            SceneManager.LoadScene(sceneToLoad); // Skifter scene
        }
    }
}
