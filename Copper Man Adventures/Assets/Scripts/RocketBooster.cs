using UnityEngine;

public class RocketBooster : MonoBehaviour
{
    public float boosterForce = 10f; // Adjust this value as needed

    private void FixedUpdate()
    {
        // Apply force upward from the bottom of the calf in the direction it's facing
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 boosterDirection = transform.up; // Get the upward direction
        Vector2 boosterPosition = transform.position - transform.up * 0.5f; // Position at the bottom of the calf
        rb.AddForceAtPosition(boosterDirection * boosterForce, boosterPosition);
    }
}
