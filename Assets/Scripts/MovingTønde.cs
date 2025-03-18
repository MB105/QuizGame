using UnityEngine;

public class MovingTønde : MonoBehaviour
{
    public float speed;      // Hastighed af bevægelsen
    public float amplitude;  // Hvor langt tønden bevæger sig til siden

    private Vector3 startPos;

    void Start()
    {
        // Gem startpositionen for at beregne bevægelsesoffset
        startPos = transform.position;
    }

    void Update()
    {
        // Beregn en ny X-position baseret på en sinusfunktion
        float newX = startPos.x + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(newX, startPos.y, startPos.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Hvis spilleren rammes (forudsætter at spilleren har tagget "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerDeath>().Respawn();
        }
    }
}

