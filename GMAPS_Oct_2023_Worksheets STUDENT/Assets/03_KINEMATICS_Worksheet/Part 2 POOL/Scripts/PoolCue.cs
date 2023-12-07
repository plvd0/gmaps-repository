using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Checks if the left click is pressed
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Gets the position where the line drawing will start using the mouse position on the screen
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y)) // Check if the mouse click is on the ball and if so initiate the line drawing
            {
                drawnLine = lineFactory.GetLine(ball.transform.position, startLinePos, 1f, Color.white); // Creates a line from the ball's current position to the starting position with white color and 1f thickness
                drawnLine.EnableDrawing(true); // Enables the line drawing
            }
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null) // Checks if the left click is released and a line is being drawn
        {
            drawnLine.EnableDrawing(false); // Disables the line drawing

            //update the velocity of the white ball.
            HVector2D v = new HVector2D(drawnLine.end.x - drawnLine.start.x, drawnLine.end.y - drawnLine.start.y); // Updates the velocity of the ball based on the drawn line
            ball.Velocity = v;

            drawnLine = null; // End line drawing            
        }

        if (drawnLine != null)
        {
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Update line end
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive(); // Gets a list of active lines from LineFactory

        foreach (var line in activeLines) // Deactivates each active line
        {
            line.gameObject.SetActive(false);
        }
    }
}