using UnityEngine;
using TMPro; 

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 

    void Update()
    {
        if (InventoryManager.instance != null)
        {
            scoreText.text = "Nøgler: " + InventoryManager.instance.score;
        }
    }
}
