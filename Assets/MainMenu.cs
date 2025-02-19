using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        // Hvis spilleren trykker på ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu"); // Skift til din startmenu-scene
        }
    }

    // Starter spillet
    public void StartGame()
    {
        SceneManager.LoadScene("quizgame"); // Skift "quizgame" til din spilscene
    }

    // Lukker spillet
    public void QuitGame()
    {
        Debug.Log("Spillet lukker!"); // Kan ses i konsollen i Unity
        Application.Quit(); // Lukker spillet (virker kun i bygget version)
    }
}


