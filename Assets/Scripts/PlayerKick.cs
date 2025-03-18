using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    public float kickForce = 10f; // Adjust this to control the strength of the kick
    public float upwardForce = 3f; // Slight upward force for the ball
    private Rigidbody rb;
    private Camera playerCamera;
    public Transform ball;  // Drag the ball object in the inspector
    public AudioSource kickSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the player's Rigidbody if needed
        playerCamera = Camera.main;  // Reference to the camera
    }

    void Update()
    {
        // Check if the player presses the kick button (left mouse button, for example)
        if (Input.GetMouseButtonDown(0)) // 0 means left mouse button
        {
            KickBall();
        }
    }

    void KickBall()
    {
        // Make sure the ball has a Rigidbody
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            // Get direction the player is facing (based on the camera)
            Vector3 directionToKick = (ball.position - playerCamera.transform.position).normalized;

            // Apply force to the ball in the direction the player is facing
            Vector3 finalKickDirection = directionToKick + Vector3.up * upwardForce;  // Adding slight upward force

            // Apply the final force to the ball
            ballRb.AddForce(finalKickDirection * kickForce, ForceMode.Impulse);

            kickSound.Play();

            // Optionally, you can add some randomness to the direction for a more dynamic effect
            // For example, applying force in a slightly random direction:
            // ballRb.AddForce(finalKickDirection * kickForce + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)), ForceMode.Impulse);
        }
    }
}


