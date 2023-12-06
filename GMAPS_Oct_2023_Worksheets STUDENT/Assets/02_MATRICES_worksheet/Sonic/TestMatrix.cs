using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D(); // Initializes a new HMatrix2D object to test & print the Identity Matrix
    private HMatrix2D mat1 = new HMatrix2D(); // Initializes a new HMatrix2D object to test with mat2 for Matrix Multiplciation
    private HMatrix2D mat2 = new HMatrix2D(); // Initializes a new HMatrix2D object to test with mat1 for Matrix Multiplication
    private HMatrix2D resultMat = new HMatrix2D(); // Initializes a new HMatrix2D object to get the result of mat1 * mat2

    void Start() // Executes this code upon Play
    {
        mat.SetIdentity(); // Sets "mat" object to be an Identity Matrix
        mat.Print(); // Prints "mat" inside console

        Question2(); // Runs Question2() method
    }

    void Question2()
    {
        HVector2D vec1 = new HVector2D(3, 7); // Initializes a new HVector2D object with the values of XY to be 3 & 7
        HVector2D resultVec = mat1 * vec1; // Initializes a new HVector2D object to get the result of mat1 * vec1 (Matrix & Vector Multiplication)

        mat1 = new HMatrix2D // Sets "mat1" matrix to be 3x3
            (0, 11, 4, 
            8, 35, 3, 
            16, 5, 21);
        Debug.Log("Matrix1: ");
        mat1.Print(); // Prints "mat1" inside console

        mat2 = new HMatrix2D // Sets "mat2" to be 3x3
            (17, 9, 5, 
            6, 18, 0, 
            54, 13, 1);
        Debug.Log("Matrix2: ");
        mat2.Print(); // Prints "mat2" inside console

        resultMat = mat1 * mat2; // Assigns the Matrix Multiplcation result between mat1 & mat2 to be resultMat
        Debug.Log("Matrix Multiplication: ");
        resultMat.Print(); // Prints the result of the Matrix Multiplication in console

        resultVec = mat1 * vec1; // Assigns the Matrix & Vector Multiplication result b etween mat1 & vec1 to be resultVec
        Debug.Log("Matrix & Vector Multiplication: " + resultVec.x + "," + resultVec.y); // Prints the result of the multiplication in console of the X & Y values of resultVec
    }
}
