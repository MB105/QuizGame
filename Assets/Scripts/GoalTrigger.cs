using UnityEngine;
using TMPro;

public class GoalTrigger : MonoBehaviour
{
    public TextMeshProUGUI goalMessage;
    public Animator goalkeeperAnimator;
    public string diveLeftTrigger = "DiveLeft";  
    public string diveRightTrigger = "DiveRight";  
    public string idleTrigger = "Idle";   
    public GoalkeeperScript goalkeeperScript;
    
   
    public static bool isGoal = false;

    public AudioSource goalSoundSource; 
    public AudioClip goalSoundClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
{
    
    if (!goalkeeperScript.GetBallCaught())
    {
        
        isGoal = true;

        
        ShowGoalMessage("MÅL!!! Du har fået en nøgle");

        
        goalSoundSource.PlayOneShot(goalSoundClip);

        
        InventoryManager.instance.AddScore(1);

        
        goalkeeperScript.ResetGoalkeeperState();

       
        GameSceneManager.instance.LoadSceneWithDelay("quizgame", 6.0f);
    }
}

    }

    
    void ShowGoalMessage(string message)
    {
        GoalMessageManager.instance.ShowMessage(message);
    }
}
