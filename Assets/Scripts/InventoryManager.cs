using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; // Singleton-instance
    public int score = 0; // Point (nøgler i dette tilfælde)

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Bevar objektet mellem scener
        }
        else
        {
            Destroy(gameObject); // Undgå dubletter
        }

        // Sørg for at hente gemte nøgler, hvis de eksisterer
        score = PlayerPrefs.GetInt("Keys", 0); 
    }

    public void AddScore(int amount)
    {
        score += amount; // Tilføj point (nøgler)
        PlayerPrefs.SetInt("Keys", score); // Gem pointene i PlayerPrefs
        PlayerPrefs.Save(); // Sørg for at gemme ændringerne
        Debug.Log("Nuværende score (nøgler): " + score);
    }

    public int GetKeyCount()
    {
        return score; // Hent det aktuelle antal nøgler
    }
}




