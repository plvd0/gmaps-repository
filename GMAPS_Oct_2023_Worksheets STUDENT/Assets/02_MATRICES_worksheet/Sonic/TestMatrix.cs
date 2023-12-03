using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();
    private HMatrix2D mat1 = new HMatrix2D();
    private HMatrix2D mat2 = new HMatrix2D();
    private HMatrix2D resultMat = new HMatrix2D();

    void Start()
    {
        mat.SetIdentity();
        mat.Print();

        Question2();
    }

    void Question2()
    {
        HVector2D vec1 = new HVector2D(3, 7);
        HVector2D resultVec = mat1 * vec1;

        mat1 = new HMatrix2D
            (0, 11, 4, 
            8, 35, 3, 
            16, 5, 21);
        Debug.Log("Matrix1: ");
        mat1.Print();

        mat2 = new HMatrix2D
            (17, 9, 5, 
            6, 18, 0, 
            54, 13, 1);
        Debug.Log("Matrix2: ");
        mat2.Print();

        resultMat = mat1 * mat2;
        Debug.Log("Matrix Multiplication: ");
        resultMat.Print();

        resultVec = mat1 * vec1;
        Debug.Log("Matrix & Vector Multiplication: " + resultVec.x + "," + resultVec.y);
    }
}
