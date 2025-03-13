using UnityEngine;
using TMPro; // Husk at importere TextMeshPro!

public class GoalTrigger : MonoBehaviour
{
    public TextMeshProUGUI goalMessage; // Reference til UI-beskeden
    public float messageDuration = 3f; // Hvor længe beskeden skal vises

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Tjekker om det er bolden
        {
            ShowGoalMessage();
            InventoryManager.instance.AddScore(1); // Tilføjer 1 nøgle
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
}
