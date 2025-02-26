using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizTrigger : MonoBehaviour
{
    public GameObject quizPanel; 
    public TMP_Text questionText;  
    public Button[] answerButtons; 
    public int correctAnswerIndex; 
    public int pointsPerCorrectAnswer = 10;
    private bool quizActive = false;

    void Start()
    {
        quizPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !quizActive)
        {
            quizActive = true;
            quizPanel.SetActive(true);
            ShowQuestion();
            Debug.Log("🎯 Quiz aktiveret!");
        }
    }

    void ShowQuestion()
    {
        questionText.text = "Hvornår opdagede Christoffer Columbus Amerika?";
        answerButtons[0].GetComponentInChildren<TMP_Text>().text = "1492";
        answerButtons[1].GetComponentInChildren<TMP_Text>().text = "1453";
        answerButtons[2].GetComponentInChildren<TMP_Text>().text = "1521";

        correctAnswerIndex = 0; 

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].onClick.RemoveAllListeners();
            int buttonIndex = i; 
            answerButtons[i].onClick.AddListener(() => CheckAnswer(buttonIndex));
        }

        Debug.Log("✅ Quiz spørgsmål og knapper sat op!");
    }

   void CheckAnswer(int index)
{
    Debug.Log($"🎯 CheckAnswer KALDT! Index: {index}");

    if (index == correctAnswerIndex)
    {
        Debug.Log($"✅ Rigtigt svar! +{pointsPerCorrectAnswer} point");
        ScoreManager.instance.AddPoints(pointsPerCorrectAnswer); // Tilføjer point
    }
    else
    {
        Debug.Log("❌ Forkert svar!");
    }

    Invoke("HideQuiz", 0.5f); // Skjuler quizzen efter svar
}


    void HideQuiz()
    {
        quizPanel.SetActive(false); 
        quizActive = false;
        Debug.Log("📉 Quiz skjult!");
    }
}





