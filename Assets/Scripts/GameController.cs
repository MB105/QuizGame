using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape pressed! Skifter til hovedmenu.");
            SceneManager.LoadScene("MainMenu"); // Skift til menuen
        }
    }
}

