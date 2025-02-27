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

    // Feedback UI elementer
    public GameObject feedbackPanel; 
    public TMP_Text feedbackText; 
    public AudioClip correctAnswerSound; 
    public AudioClip wrongAnswerSound; 
    private AudioSource audioSource;

    void Start()
    {
        quizPanel.SetActive(false);
        feedbackPanel.SetActive(false); // Feedbackpanel er skjult som standard
        audioSource = GetComponent<AudioSource>();
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

        correctAnswerIndex = 0; // Indstil korrekt svar (1492)

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

        // Vis feedback baseret på svar
        if (index == correctAnswerIndex)
        {
            Debug.Log($"✅ Rigtigt svar! +{pointsPerCorrectAnswer} point");
            ScoreManager.instance.AddPoints(pointsPerCorrectAnswer); // Tilføjer point
            ShowFeedback("Rigtigt svar!", correctAnswerSound);
        }
        else
        {
            Debug.Log("❌ Forkert svar!");
            ShowFeedback("Forkert svar!", wrongAnswerSound);
        }

        //Invoke("HideQuiz", 1.5f); // Skjuler quizzen efter 1,5 sekunder
    }

    // Vis feedback og afspil lyd
    void ShowFeedback(string message, AudioClip sound)
    {
        Debug.Log("📢 Prøver at vise feedbackPanel...");
        quizPanel.SetActive(false);
        feedbackPanel.SetActive(true);
        Debug.Log("✅ feedbackPanel er nu aktiveret!");
        feedbackText.text = message; // Opdaterer feedback teksten
        audioSource.PlayOneShot(sound); // Afspiller den korrekte lyd

        Invoke("HideQuiz", 5.0f);

        Debug.Log($"💬 {message}"); // Log besked
    }

    // Skjul quiz og feedback panel
    void HideQuiz()
    {
        quizPanel.SetActive(false);
        feedbackPanel.SetActive(false); // Skjuler feedback panel
        quizActive = false;
        Debug.Log("📉 Quiz skjult!");
    }
}
