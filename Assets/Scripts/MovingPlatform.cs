using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f; // Hastighed af bevægelsen
    public float height = 2f; // Hvor højt platformen bevæger sig

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Gem startpositionen
    }

    void Update()
    {
        // Bevæger platformen op og ned som en bølge
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}