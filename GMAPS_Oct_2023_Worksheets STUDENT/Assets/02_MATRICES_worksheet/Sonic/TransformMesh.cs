using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    private HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y); // Gets the X & Y coordinates of the Sonic's current position in the scene

        Translate(1, 1);
        //Rotate(45);
    }

    void Translate(float x, float y) // Moves the Sonic sprite based on X & Y values
    {
        transformMatrix.SetIdentity(); // Sets the transformationMatrix to an Identity Matrix
        transformMatrix.SetTranslationMatrix(x, y); // Uses the TranslationMatrix method to update the transformMatrix with the X & Y translation values
        Transform(); // Method is called to apply the translation of the sprite's vertices

        pos = transformMatrix * pos; // Update the position of the Sonic sprite by applying the transformationMatrix to current position
    }

    void Rotate(float angle) // Rotates the Sonic sprite around an angle
    {
        HMatrix2D toOriginMatrix = new HMatrix2D(); // Initializes a new HMatrix2D object to translate the vertices to the origin (0,0)
        HMatrix2D fromOriginMatrix = new HMatrix2D(); // Initializes a new HMatrix2D object to translate the vertices back from the origin
        HMatrix2D rotateMatrix = new HMatrix2D(); // Initializes a new HMatrix2D object to rotate the sprite around the angle

        toOriginMatrix.SetTranslationMatrix(-pos.x, -pos.y); // Uses the TranslationMatrix method to move to the origin
        fromOriginMatrix.SetTranslationMatrix(pos.x, pos.y); // Uses the TranslationMatrix method to move back from the origin

        rotateMatrix.SetRotationMatrix(angle); // Uses the RotationMatrix method to rotate the sprite

        transformMatrix.SetIdentity(); // Sets the transformMatrix to an Identity Matrix
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix; // Updated by multiplying the 3 matrices together

        Transform(); // Method is called to apply the rotation of the sprite's vertices
    }

    private void Transform() // Method to apply the transformation of rotation and/or translation to the Sonic sprite
    {
        vertices = meshManager.originalMesh.vertices; // Gets the vertices of the originalMesh from the sprite

        for (int i = 0; i < vertices.Length; i++) // Runs a loop through each vertex in the mesh, for Sonic it's 4 since it's a Quad
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y); // Creates a homogenous vector from the current vertex in the loop
            vert = transformMatrix * vert; // Applies the transformation matrix to the current vertex using Vector & Matrix Multiplication
            vertices[i].x = vert.x; // Updates the X value of the current vertex with the transformation
            vertices[i].y = vert.y; // Updates the Y value of the current vertex with the transformation
        }
        meshManager.originalMesh.vertices = vertices; // Updates the vertices with the transformed vertices, applying the transformation
    }
}