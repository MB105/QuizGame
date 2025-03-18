using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizTrigger2 : MonoBehaviour
{
    public GameObject quizPanel; 
    public TMP_Text questionText;  
    public Button[] answerButtons; 
    public int correctAnswerIndex; 
    private bool quizActive = false;

    // Feedback UI elementer
    public GameObject feedbackPanel; 
    public TMP_Text feedbackText; 
    public AudioClip correctAnswerSound; 
    public AudioClip wrongAnswerSound; 
    private AudioSource audioSource;

    void Start()
    {
        quizPanel.SetActive(false);
        feedbackPanel.SetActive(false); 
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !quizActive)
        {
            quizActive = true;
            quizPanel.SetActive(true);
            ShowQuestion();
        }
    }

    void ShowQuestion()
    {
        questionText.text = "Hvornår har Marwa Fødselsdag?";
        answerButtons[0].GetComponentInChildren<TMP_Text>().text = "21. september";
        answerButtons[1].GetComponentInChildren<TMP_Text>().text = "22. september";
        answerButtons[2].GetComponentInChildren<TMP_Text>().text = "23. september";

        correctAnswerIndex = 0; 

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].onClick.RemoveAllListeners();
            int buttonIndex = i; 
            answerButtons[i].onClick.AddListener(() => CheckAnswer(buttonIndex));
        }
    }

    void CheckAnswer(int index)
    {

        if (index == correctAnswerIndex)
        {
            InventoryManager.instance.AddScore(1);
            ShowFeedback("Rigtigt svar! Du har fået en nøgle", correctAnswerSound);
        }
        else
        {
            ShowFeedback("Forkert svar", wrongAnswerSound);
        }
    }

    void ShowFeedback(string message, AudioClip sound)
    {
        quizPanel.SetActive(false);
        feedbackPanel.SetActive(true);
        feedbackText.text = message; 
        audioSource.PlayOneShot(sound); 

        Invoke("HideQuiz", 5.0f);

    }

    void HideQuiz()
    {
        quizPanel.SetActive(false);
        feedbackPanel.SetActive(false); 
        quizActive = false;
    }
}