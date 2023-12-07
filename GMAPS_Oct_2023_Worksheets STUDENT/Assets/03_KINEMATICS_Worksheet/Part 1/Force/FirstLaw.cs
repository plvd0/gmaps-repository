using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour 
{
    public Vector3 force; // Sets the Force vector in Inspector
    Rigidbody rb; // References the Rigidbody component from the GameObject

    void Start() 
    {
        rb = GetComponent<Rigidbody>(); 
        rb.AddForce(force, ForceMode.Impulse); // Applies an instant force using its mass to the Rigidbody using the specified Force vector
    }

    void FixedUpdate() 
    {
        Debug.Log(transform.position); // Logs the current position of GameObject in console
    }
}