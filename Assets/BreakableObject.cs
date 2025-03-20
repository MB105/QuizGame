using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public BreakableObjectData objectData; 
    private int jumpCount = 0; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            jumpCount++;

            if (jumpCount >= objectData.requiredJumps) 
            {
                Destroy(gameObject); 
            }
        }
    }
}





