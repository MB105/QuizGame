using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public EnemyAI enemyAI; // Reference til EnemyAI scriptet

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("💥 Player har trådt ind i triggeren!");
            enemyAI.StartChase();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("❌ Player har forladt triggeren!");
            enemyAI.StopChase();
        }
    }
}




