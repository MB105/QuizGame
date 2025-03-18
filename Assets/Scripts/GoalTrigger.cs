using UnityEngine;
using TMPro;

public class GoalTrigger : MonoBehaviour
{
    public TextMeshProUGUI goalMessage;
    public float messageDuration = 4f;
    public Animator goalkeeperAnimator;
    public string diveLeftTrigger = "DiveLeft";  // Animator trigger for left dive
    public string diveRightTrigger = "DiveRight";  // Animator trigger for right dive
    public string idleTrigger = "Idle";    // Idle animation trigger
    public GoalkeeperScript goalkeeperScript;
    
    // Static flag to track if a goal was scored
    public static bool isGoal = false;

    public AudioSource goalSoundSource; // Reference to AudioSource
    public AudioClip goalSoundClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
{
    // Check if the goalkeeper has not caught the ball before declaring a goal
    if (!goalkeeperScript.GetBallCaught())
    {
        // Set the goal flag to true
        isGoal = true;

        // Show the "Goal" message
        ShowGoalMessage("MÅL!!! Du har fået en nøgle");

        // Play the goal sound
        goalSoundSource.PlayOneShot(goalSoundClip);

        // Add score for the goal
        InventoryManager.instance.AddScore(1);

        // Reset goalkeeper's catch state for the next attempt
        goalkeeperScript.ResetGoalkeeperState();

        // Delay scene change after scoring a goal
        GameSceneManager.instance.LoadSceneWithDelay("quizgame", 6.0f);
    }
}

    }

    // Implement GoalMessageManager to show the goal message
    void ShowGoalMessage(string message)
    {
        GoalMessageManager.instance.ShowMessage(message);
    }
}
