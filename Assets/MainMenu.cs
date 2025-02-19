using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
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


