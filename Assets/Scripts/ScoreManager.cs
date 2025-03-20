using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 
    public TMP_Text scoreText; 
    private int score = 0; 

    void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    
    public void AddPoints(int points)
    {
        score += points; 
        UpdateScoreText(); 
    }

    
    void UpdateScoreText()
    {
        scoreText.text = "Point: " + score;
    }
}

