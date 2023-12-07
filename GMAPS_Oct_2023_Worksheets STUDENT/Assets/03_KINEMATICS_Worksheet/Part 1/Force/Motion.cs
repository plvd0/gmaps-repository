using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity; // Sets the Velocity vector in Inspector

    void FixedUpdate() 
    {
        float dt = Time.deltaTime; // Gets the time passed since last frame

        float dx = Velocity.x * dt; // Calculates the displacement in the X-axis based on the velocity multiplied by time
        float dy = Velocity.y * dt; // Calculates the displacement in the Y-axis based on the velocity multiplied by time
        float dz = Velocity.z * dt; // Calculates the displacement in the Z-axis based on the velocity multiplied by time

        transform.Translate(new Vector3(dx, dy, dz)); // Moves the GameObject by the calculated displacement
    }
}