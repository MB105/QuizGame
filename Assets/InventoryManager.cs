using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; // Singleton-instance
    public int score = 0; // Point

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
    }

    public void AddScore(int amount)
    {
        score += amount; // Tilføjer point
        Debug.Log("Nuværende score: " + score);
    }

    // Brug en nøgle
    public void UseKey()
    {
        if (score > 0)
        {
            score--;
            Debug.Log("🔓 Nøgle brugt! Tilbageværende nøgler: " + score);
        }
    }

    // Hent antallet af nøgler
    public int GetKeyCount()
    {
        return score;
    }
}


