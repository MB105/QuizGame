using UnityEngine;
using TMPro;

public class GoalMessageManager : MonoBehaviour
{
    public static GoalMessageManager instance;
    public TextMeshProUGUI goalMessage;
    public float messageDuration = 3f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowMessage(string message)
    {
        CancelInvoke("HideGoalMessage");
        goalMessage.gameObject.SetActive(true);
        goalMessage.text = message;
        Invoke("HideGoalMessage", messageDuration);
    }

    private void HideGoalMessage()
    {
        goalMessage.gameObject.SetActive(false);
    }
}
