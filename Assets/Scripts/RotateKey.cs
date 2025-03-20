using UnityEngine;

public class RotateKey : MonoBehaviour
{
    public float rotationSpeed; 

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

