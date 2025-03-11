using UnityEngine;

public class MovingTønde : MonoBehaviour
{
    public float speed = 2f;      // Hastighed af bevægelsen
    public float amplitude = 2f;  // Hvor langt tønden bevæger sig til siden

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
            Debug.Log("Spilleren blev ramt af tønden!");
            // Forudsætter, at spilleren har et script med en Respawn()-metode
            collision.gameObject.GetComponent<PlayerDeath>().Respawn();
        }
    }
}

