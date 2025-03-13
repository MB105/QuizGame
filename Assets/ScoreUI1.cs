using UnityEngine;
using TMPro; // Importer TextMeshPro namespace

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference til TextMeshPro UI-teksten

    void Update()
    {
        if (InventoryManager.instance != null)
        {
            scoreText.text = "Nøgler: " + InventoryManager.instance.score;
        }
    }
}
