using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton for at gøre det let at tilgå score systemet
    public TMP_Text scoreText; // Referencer til UI-teksten
    private int score = 0; // Spillerens point

    void Awake()
    {
        // Sørger for, at der kun er én ScoreManager i scenen
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        UpdateScoreText(); // Opdater UI fra start
    }

    // Metode til at tilføje point
    public void AddPoints(int points)
    {
        score += points; // Lægger point til scoren
        UpdateScoreText(); // Opdaterer UI
    }

    // Opdaterer point UI-teksten
    void UpdateScoreText()
    {
        scoreText.text = "Point: " + score;
    }
}

