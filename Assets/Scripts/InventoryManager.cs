using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; 
    public int score = 0; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void AddScore(int amount)
    {
        score += amount; 
    }


    public int GetKeyCount()
    {
        return score;
    }
}


