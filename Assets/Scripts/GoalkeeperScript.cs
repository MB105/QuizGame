using UnityEngine;
using TMPro;

public class GoalkeeperScript : MonoBehaviour
{
    private Animator goalkeeperAnimator;
    public Transform ballTransform; 
    public string diveLeftTrigger = "DiveLeft";  
    public string diveRightTrigger = "DiveRight";  
    public string idleTrigger = "Idle";    
    private bool ballCaught = false; 
    public TextMeshProUGUI goalMessage;

    private Rigidbody ballRigidbody; 
    public MovementBoundary movementBoundary;  

    void Start()
    {
        goalkeeperAnimator = GetComponent<Animator>();

        if (ballTransform != null)
        {
            ballRigidbody = ballTransform.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (ballTransform == null || ballRigidbody == null || movementBoundary == null) return;

        float ballSpeed = ballRigidbody.linearVelocity.magnitude;

        if (movementBoundary.IsBallInsideTrigger())
        {
            HandleGoalkeeperDive(ballSpeed);
        }
        else
        {
            StopDiving(); 
        }
    }

    public void HandleGoalkeeperDive(float ballSpeed)
{
    
    Vector3 directionToBall = ballTransform.position - transform.position;
    float xDifference = directionToBall.x;
    float zDifference = directionToBall.z;

    
    float randomReactionTime = Random.Range(0.5f, 1.0f);

    
    float adjustedXDistance = Mathf.Abs(xDifference) - ballSpeed * randomReactionTime;

    
   if (adjustedXDistance <= 0)
    {
        TriggerDive(zDifference);
    }
}

    void TriggerDive(float zDifference)
    {
        if (zDifference > 0) 
        {
            goalkeeperAnimator.SetTrigger(diveRightTrigger);
        }
        else if (zDifference < 0) 
        {
            goalkeeperAnimator.SetTrigger(diveLeftTrigger);
        }
    }

    public void StopDiving()
    {
        goalkeeperAnimator.ResetTrigger(diveRightTrigger);
        goalkeeperAnimator.ResetTrigger(diveLeftTrigger);
        goalkeeperAnimator.SetTrigger(idleTrigger);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !ballCaught)
        {
            ballCaught = true;
            StopDiving();
            ShowGoalMessage();
            GameSceneManager.instance.LoadSceneWithDelay("quizgame", 6.0f);
        }
    }

    public bool GetBallCaught()
    {
        return ballCaught;
    }

    public void ResetGoalkeeperState()
    {
        ballCaught = false;
    }

    
    public void ShowGoalMessage()
    {
        GoalMessageManager.instance.ShowMessage("Målmanden greb bolden. Du får ingen nøgle.");

       
    }


}



