using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed; 
    public float height; 

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; 
    }

    void Update()
    {
        // Bevæger platformen op og ned som en bølge
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}