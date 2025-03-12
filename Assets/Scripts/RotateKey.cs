using UnityEngine;

public class RotateKey : MonoBehaviour
{
    public float rotationSpeed = 50f; // Juster hastigheden på rotationen

    void Update()
    {
        // Får objektet til at rotere omkring sin egen akse (Y-aksen)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

