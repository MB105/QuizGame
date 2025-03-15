using UnityEngine;
using TMPro; 

public class GoalTrigger : MonoBehaviour
{
    public TextMeshProUGUI goalMessage; 
    public float messageDuration = 3f; 
    public Animator goalkeeperAnimator; 
    public string diveLeftTrigger = "DiveLeft";  // Animator trigger for left dive
    public string diveRightTrigger = "DiveRight";  // Animator trigger for right dive
    public string idleTrigger = "Idle";    // Idle animation trigger

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Ball")) // Check if it's the ball
    {
        // Check if the collision is not with the goalkeeper
        if (!other.CompareTag("Goalkeeper")) // Ensure it's not the goalkeeper
        {
            StopGoalkeeperDive();   // Stop diving when the ball enters the trigger
            ShowGoalMessage();      // Show the goal message when the ball enters
            InventoryManager.instance.AddScore(1); // Add 1 to the score (key)
        }
    }
}

    void ShowGoalMessage()
    {
        goalMessage.gameObject.SetActive(true); // Vis besked
        goalMessage.text = "MÅL!!! Du har fået en nøgle";
        Invoke("HideGoalMessage", messageDuration); // Skjul beskeden efter tid
    }

    void HideGoalMessage()
    {
        goalMessage.gameObject.SetActive(false); // Skjul besked
    }

    void StopGoalkeeperDive()
    {
          if (goalkeeperAnimator == null) return;
          
            goalkeeperAnimator.ResetTrigger(diveRightTrigger);
            goalkeeperAnimator.ResetTrigger(diveLeftTrigger);
            goalkeeperAnimator.SetTrigger(idleTrigger);
        }
}
