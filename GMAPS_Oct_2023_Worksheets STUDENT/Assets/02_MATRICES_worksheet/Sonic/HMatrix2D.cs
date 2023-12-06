using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3]; // Initializes a 3x3 array of floats, with the Entries value able to be modified

    public HMatrix2D() // Default constructor where it initializes a identity matrix
    {
        Entries[0, 0] = 1.0f; // Sets top left of matrix to 1
        Entries[0, 1] = 0.0f; // Sets top middle of matrix to 0
        Entries[0, 2] = 0.0f; // Sets top right of matrix to 0

        Entries[1, 0] = 0.0f; // Sets middle left of matrix to 0
        Entries[1, 1] = 1.0f; // Sets middle of matrix to 1
        Entries[1, 2] = 0.0f; // Sets middle right of matrix to 0

        Entries[2, 0] = 0.0f; // Sets bottom left of matrix to 0
        Entries[2, 1] = 0.0f; // Sets bottom middle of matrix to 0 
        Entries[2, 2] = 1.0f; // Sets bottom right of matrix to 1
    }

    public HMatrix2D(float[,] multiArray) // Another method to initialize the HMatrix2D object, utilizing loops
    {
        if(multiArray.GetLength(0) == 3 && multiArray.GetLength(1) == 3) // Checks if multiArray has 3 rows & columns
        {
            for(int r = 0; r < 3; r++) // Loops through each row & column of the multiArray via nested loop
            {
                for(int c = 0; c < 3; c++) 
                {
                    Entries[r,c] = multiArray[r,c]; // Assigns the specific value of the rows & columns in multiArray as the Entries in HMatrix2D object
                }
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02, // Another method to initialize the HMatrix2D object, utilizing individual values
        float m10, float m11, float m12,
        float m20, float m21, float m22)
    {
        Entries[0, 0] = m00; // Assigns the value to the top left of matrix
        Entries[0, 1] = m01; // Assigns the value to the top middle of matrix
        Entries[0, 2] = m02; // Assigns the value to the top right of matrix

        Entries[1,0] = m10; // Assigns the value to the middle left of matrix
        Entries[1, 1] = m11; // Assigns the value to the middle of matrix
        Entries[1, 2] = m12; // Assigns the value to the middle right of matrix
         
        Entries[2, 0] = m20; // Assigns the value to the bottom left of matrix
        Entries[2, 1] = m21; // Assigns the value to the bottom middle of matrix
        Entries[2, 2] = m22; // Assigns the value to the bottom right of matrix
    }

    public void SetIdentity() // Resets the current matrix to an identity matrix
    {
        for(int y = 0; y < 3; y++) // Loops through each row & column of the matrix via nested loop
        {
            for(int x = 0; x < 3; x++)
            {
                Entries[x, y] = (x == y) ? 1.0f : 0.0f; // If the current row & column that it's looping through are the same diagonally, sets it to 1. Otherwise, all other Entries is set to 0
            }
        }
    }

    public void Print() // Prints out the matrix in console
    {
        string result = ""; // Initiliazes a string to store the matrix result
        for(int r = 0; r < 3; r++) // Loops through each row & column of the matrix via nested loop
        {
            for(int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  "; // Inserts the current row & column value that it's looping through of the matrix to the string
            }
            result += "\n"; // Breaks the line to indicate a new row after it finishes looping through each row
        }
        Debug.Log(result); // After the loop is finished, it prints the result of the matrix inside the console
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right) // Basic arithmetical addition between 2 matrices
    {
        HMatrix2D aResult = new HMatrix2D(); // Initializes a new HMatrix2D object to store the result of the addition
        for (int r = 0; r < 3; r++) // Loops through each row & column of both the matrices via nested loop
        {
            for (int c = 0; c < 3; c++)
            {
                aResult.Entries[r, c] = left.Entries[r, c] + right.Entries[r, c]; // Adds together the current row & column value that it's at (eg. both of the top left is added together) and assigns it to the matrix result
            }
        }
        return aResult; // Returns the result of the addition
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right) // Basic arithmetical subtraction between 2 matrices
    {
        HMatrix2D mResult = new HMatrix2D(); // Initializes a new HMatrix2D object to store the result of the subtraction
        for(int r = 0; r < 3; r++) // Loops through each row & column of both the matrices via nested loop
        {
            for(int c = 0; c < 3; c++)
            {
                mResult.Entries[r, c] = left.Entries[r, c] - right.Entries[r, c]; // Minuses together the current row & column value that it's at (eg. both of the top left is subtracted together) and assigns it to the matrix result
            }
        }
        return mResult; // Returns the result of the subtraction
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar) // Basic arithmetical scalar for a matrix
    {
        HMatrix2D sResult = new HMatrix2D(); // Initalizes a new HMatrix2D object to store the result of the scaling
        for (int r = 0; r < 3; r++) // Loops through each row & column of the matrix via nested loop
        {
            for (int c = 0; c < 3; c++)
            {
                sResult.Entries[r, c] = left.Entries[r, c] * scalar; // Multiplies the current row & column value that it's at by the scalar value and assigns it to the matrix result
            }
        }
        return sResult; // Returns the result of the scaling
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right) // Checks between 2 matrices if they're equal (corresponding row & column elements are the same)
    {
        for(int r = 0; r < 3; r++) // Loops through each row & column of both matrices via nested loop
        {
            for(int c = 0; c < 3; c++)
            {
                if (left.Entries[r, c] != right.Entries[r, c]) // Checks if the current row & column value that it's at is not equal to the other corresponding matrix value (eg. if both of the top left value is the same)
                {
                    return false; // Returns "False" if the corresponding row & column elements of both matrices are not the same
                }
            }
        }
        return true; // Otherwise, returns "True" if the corresponding row & column elements of both matrices are the same
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right) // Similar to the above method, however works in reverse
    {
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                if (left.Entries[r, c] != right.Entries[r, c])
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static HVector2D operator *(HMatrix2D left, HVector2D right) // Multiplication between a vector & matrix
    {
        return new HVector2D // Returns a HVector2D result that will have the multiplied X & Y values
            (
            left.Entries[0,0] * right.x + left.Entries[0,1] * right.y + left.Entries[0,2] * right.h, // Calculates the X value of the vector
            left.Entries[1,0] * right.x + left.Entries[1,1] * right.y + left.Entries[1,2] * right.h // Calculates the Y value of the vector
            );
    }

    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right) // Multiplication between 2 matrices
    {
        return new HMatrix2D // Returns a HMatrix2D result
        {
            Entries = new float[3,3] // Initialize the result array which is a 3x3
            {
                { // Calculates the first row of the matrix
                    left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0], // Calculates the top left result of the matrix
                    left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1], // Calculates the top middle result of the matrix
                    left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2] // Calculate the top right result of the matrix
                },
                { // Calculates the second row of the matrix
                    left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0], // Calculates the middle left result of the matrix
                    left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1], // Calculates the middle result of the matrix
                    left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2] // Calculate the middle right result of the matrix
                },
                { // Calculates the third row of the matrix
                    left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0], // Calculates the bottom left result of the matrix
                    left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1], // Calculates the bottom middle result of the matrix
                    left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2] // Calculate the bottom right result of the matrix
                }
            }
        };
    }

    public void SetRotationMatrix(float rotDeg) // Method for rotation of matrices on 2D
    {
        SetIdentity(); // Sets the current matrix to an identity matrix
        float rad = rotDeg * Mathf.Deg2Rad; // Converts the rotation angle from degrees to radian

        Entries[0, 0] = Mathf.Cos(rad); // Sets the top left value to be Cosine of the angle
        Entries[0, 1] = -Mathf.Sin(rad); // Sets the top middle value to be negative Sine of the angle
        Entries[1, 0] = Mathf.Sin(rad); // Sets the middle left value to be Sine of the angle
        Entries[1, 1] = Mathf.Cos(rad); // Sets the middle value to be Cosine of the angle
    }

    public void SetTranslationMatrix(float transX, float transY) // Method for translation of matrices on 2D
    {
        SetIdentity(); // Sets the current matrix to an identity matrix
        Entries[0, 2] = transX; // Sets the top right value inside the 3x3 matrix to be transX, which transform along the X-axis
        Entries[1, 2] = transY; // Sets the middle right value inside the 3x3 matrix to be transY, which transform along the Y-axis
    }
}