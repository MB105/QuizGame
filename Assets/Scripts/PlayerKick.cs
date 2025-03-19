using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    public float kickForce = 10f; 
    public float upwardForce = 3f; 
    private Camera playerCamera;
    public Transform ball;  
    public AudioSource kickSound;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
            KickBall();
        }
    }

    void KickBall()
    {
        
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            
            Vector3 directionToKick = (ball.position - playerCamera.transform.position).normalized;

            
            Vector3 finalKickDirection = directionToKick + Vector3.up * upwardForce;

           
            ballRb.AddForce(finalKickDirection * kickForce, ForceMode.Impulse);

            kickSound.Play();

        }
    }
}


