using UnityEngine; 
using TMPro; 

public class MovementBoundary : MonoBehaviour
{
    public GoalkeeperScript goalkeeperScript; 
    private bool ballInsideTrigger = false; 
    public TextMeshProUGUI goalMessage; 
    

    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Ball"))
        {
            ballInsideTrigger = true; 
            Rigidbody ballRigidbody = other.GetComponent<Rigidbody>(); 
            if (ballRigidbody != null)
            {
                float ballSpeed = ballRigidbody.linearVelocity.magnitude; 

                
                goalkeeperScript.HandleGoalkeeperDive(ballSpeed);
            }
        }
    }

   
    void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Ball"))
        {
            ballInsideTrigger = false;  

            
            if (!GoalTrigger.isGoal) 
            {
          
                ShowGoalMessage("Du ramte ved siden af. Du får ingen nøgle.");
            }
            
            goalkeeperScript.StopDiving();
            GameSceneManager.instance.LoadSceneWithDelay("quizgame", 6.0f); 
        }
    }

    
    public bool IsBallInsideTrigger()
    {
        return ballInsideTrigger;  
    }

    
    void ShowGoalMessage(string message)
    {
        GoalMessageManager.instance.ShowMessage(message); 
    }
}




