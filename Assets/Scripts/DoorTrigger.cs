using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator; 


    private void Start()
    {
        if (doorAnimator == null)
        {
            Debug.LogError("🚨 DoorAnimator ikke sat! Træk døren ind i scriptets doorAnimator-felt i Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("Open");
            Debug.Log("🚪 Døren åbner!");
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("Close");
            Debug.Log("🚪 Døren lukker!");
        }
    }
}


