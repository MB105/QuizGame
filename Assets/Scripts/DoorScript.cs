using UnityEngine;
using UnityEngine.SceneManagement; 

public class DoorScript : MonoBehaviour
{
    public string sceneToLoad; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(sceneToLoad); 
        }
    }
}
