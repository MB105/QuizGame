using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; // Singleton instance

    private int keyCount = 0; // Antal nøgler spilleren har
    public TMP_Text scoreText; // UI tekst til at vise antal nøgler

    private void Awake()
    {
        // Sikrer, at der kun er én instance af InventoryManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Beholder objektet mellem scener
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        OpdaterScoreText(); // Sikrer, at teksten starter korrekt
    }

    public void AddKey()
    {
        keyCount++;
        Debug.Log($"🔑 Nøgle tilføjet! Total: {keyCount}");
        OpdaterScoreText();
    }

    public int GetKeyCount()
    {
        return keyCount;
    }

    public bool UseKey()
    {
        if (keyCount > 0)
        {
            keyCount--;
            Debug.Log($"🔓 Nøgle brugt! Tilbage: {keyCount}");
            OpdaterScoreText();
            return true;
        }
        else
        {
            Debug.Log("🚫 Ingen nøgler tilbage!");
            return false;
        }
    }

    public void OpdaterScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "🔑 Nøgler: " + keyCount;
        }
    }
}


