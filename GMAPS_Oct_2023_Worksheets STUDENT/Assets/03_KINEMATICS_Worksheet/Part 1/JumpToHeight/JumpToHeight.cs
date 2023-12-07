using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f; // Sets the jump height in Inspector
    Rigidbody rb; // References the Rigidbody component from the GameObject

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Jump() // Method to make the GameObject jump
    {
        //v*v = u*u + 2as
        //u*u = v*v - 2as
        //u = sqrt(v*v - 2as)
        //v = 0, u = ?, a = Physics.gravity, s = Height

        float u = Mathf.Sqrt(0 - 2f * Physics.gravity.y * Height); // Calculates the initial velocity using the kinematic equation for vertical motion
        rb.velocity = new Vector3(0f, u, 0f); // Sets the Rigidbody's velocity to achieve the calculated initial velocity in Y-axis

        //float jumpForce = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height);
        //rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // If the player presses Space, it runs Jump method
        {
            Jump();
        }
    }
}

