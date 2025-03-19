using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference til spilleren
    private NavMeshAgent agent; // NavMeshAgent
    private bool isChasing = false; // Holder styr på jagtstatus
    private Vector3 startPosition; // Enemy's startposition

    void Start()
    {
        // Hent NavMeshAgent-komponenten
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("❌ NavMeshAgent mangler på enemy!");
            return;
        }

        // Fejl, hvis spilleren ikke er sat i Inspector
        if (player == null)
        {
            Debug.LogError("❌ Player er ikke sat op i Inspector!");
        }

        // Gem enemy's startposition, så den kan vende tilbage
        startPosition = transform.position;
    }

    void Update()
{
    if (agent != null && agent.isOnNavMesh)
    {
        if (isChasing)
        {
            // Tjek om der er en forhindring mellem enemy og player
            RaycastHit hit;
            if (Physics.Linecast(transform.position, player.position, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    agent.SetDestination(player.position);
                    Debug.Log("🏃 Enemy jagter spilleren!");
                }
                else
                {
                    Debug.Log("👀 Enemy kan ikke se spilleren!");
                }
            }
        }
        else
        {
            agent.SetDestination(startPosition);
            Debug.Log("🔄 Enemy vender tilbage til sin plads.");
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




