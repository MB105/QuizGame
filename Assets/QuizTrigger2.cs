using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizTrigger2 : MonoBehaviour
{
    public GameObject quizPanel;
    public TMP_Text questionText;
    public Button[] answerButtons;
    public int correctAnswerIndex;

    private int playerScore = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowQuiz();
        }
    }

    private void ShowQuiz()
    {
        quizPanel.SetActive(true);
        questionText.text = "Hvad er 2 + 2?";

        string[] answers = { "3", "4", "5" };
        correctAnswerIndex = 1; 

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i; 
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = answers[i];
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    private void CheckAnswer(int selectedIndex)
    {
        if (selectedIndex == correctAnswerIndex)
        {
            playerScore += 10;
            Debug.Log($"✅ Korrekt! Score: {playerScore}");
        }
        else
        {
            Debug.Log("❌ Forkert svar!");
        }

        quizPanel.SetActive(false);
    }
}