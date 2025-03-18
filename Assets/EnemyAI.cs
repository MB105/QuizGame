using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference til spilleren
    private NavMeshAgent agent; // NavMeshAgent
    private bool isChasing = false; // Holder styr på jagtstatus

    void Start()
    {
        // Hent NavMeshAgent-komponenten
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("❌ NavMeshAgent mangler på enemy!");
            return;
        }
        
        // Fejl, hvis spilleren ikke er sat op i Inspector
        if (player == null)
        {
            Debug.LogError("❌ Player er ikke sat op i Inspector!");
        }
    }

    void Update()
    {
        if (agent != null && agent.isOnNavMesh)
        {
            if (isChasing)
            {
                // Sæt destination til spillerens position
                agent.SetDestination(player.position);
                Debug.Log("🏃 Enemy jagter spilleren!");
            }
            else
            {
                agent.ResetPath(); // Stop med at følge spilleren
                Debug.Log("⛔ Enemy stopper.");
            }
        }
        else
        {
            Debug.Log("❌ NavMeshAgent er ikke på NavMesh!");
        }
    }

    // Kaldt af trigger scriptet for at starte jagt
    public void StartChase()
    {
        isChasing = true;
        Debug.Log("💥 Enemy begynder at jagte spilleren!");
    }

    // Kaldt af trigger scriptet for at stoppe jagt
    public void StopChase()
    {
        isChasing = false;
        Debug.Log("❌ Enemy stopper jagten!");
    }
}



