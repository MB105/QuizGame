using UnityEngine;

public class ShootBall : MonoBehaviour
{
    public Transform ball; // Reference til bolden
    public float kickForce = 500f; // Hvor hårdt vi skyder

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Venstre klik for at skyde
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true; // Tænd for tyngdekraft
            rb.linearVelocity = Vector3.zero; // Nulstil hastighed
            rb.AddForce(transform.forward * kickForce); // Skyd fremad
        }
    }
}
