using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0); // Position of the ball in 2D space using X&Y coordinates
    public HVector2D Velocity = new HVector2D(0, 0); // Velocity of the ball in 2D space

    [HideInInspector]
    public float Radius; // Radius of the ball

    private void Start()
    {
        Position.x = transform.position.x; // Initializes the X position of the ball based on the transform position
        Position.y = transform.position.y; // Initializes the Y position of the ball based on the transform position

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit; // Size of the sprite in the local space
        Radius = local_sprite_size.x / 2f; // Takes half of the width of the local sprite to get its radius
    }

    public bool IsCollidingWith(float x, float y) // Method to check if the ball is colliding with a point in the X&Y coordinates
    {
        float distance = Util.FindDistance(new HVector2D(x, y), new HVector2D(Position.x, Position.y)); // Calculates distance between the given point and the ball's position
        return distance <= Radius; // Checks if the distance is less than or equal to the ball's radius
    }

    public bool IsCollidingWith(Ball2D other) // Checks if the ball is colliding with another ball
    {
        float distance = Util.FindDistance(Position, other.Position); // Calculates distance between the two ball's positions
        return distance <= Radius + other.Radius; // Checks if the distance is less than or equal to the sum of the ball's radius
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime); // Updates the physics of the ball based on the time in the last frame
    }

    private void UpdateBall2DPhysics(float deltaTime) 
    {
        float displacementX = Velocity.x * deltaTime; // Calculates the displacement in X axis based on multiplying the velocity and time
        float displacementY = Velocity.y * deltaTime; // Calculates the displacement in Y axis based on multiplying the velocity and time

        Position.x += displacementX; // Updates the position of the ball on the X axis based on the calculated displacement
        Position.y += displacementY; // Updates the position of the ball on the Y axis based on the calculated displacement

        transform.position = new Vector2(Position.x, Position.y); // Updates the ball's position in scene with the new calculated displacement
    }
}