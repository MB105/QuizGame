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
        quizPanel.SetActive(false); // Skjul quiz ved start
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
        questionText.text = "Hvad er 2 + 2?";
        answerButtons[0].GetComponentInChildren<TMP_Text>().text = "3";
        answerButtons[1].GetComponentInChildren<TMP_Text>().text = "4"; // Rigtigt svar
        answerButtons[2].GetComponentInChildren<TMP_Text>().text = "5";

        correctAnswerIndex = 1; // Index 1 er korrekt svar

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].onClick.RemoveAllListeners();
            int buttonIndex = i; // Lokal variabel for korrekt lambda
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
        }
        else
        {
            Debug.Log("❌ Forkert svar!");
        }

        Invoke("HideQuiz", 0.5f);
    }

    void HideQuiz()
    {
        quizPanel.SetActive(false); 
        quizActive = false;
        Debug.Log("📉 Quiz skjult!");
    }
}





