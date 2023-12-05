using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3]; // Initializes a 3x3 array of floats, with the Entries value able to be modified

    public HMatrix2D() // Default constructor where it initializes a identity matrix
    {
        Entries[0, 0] = 1.0f;
        Entries[0, 1] = 0.0f;
        Entries[0, 2] = 0.0f;

        Entries[1, 0] = 0.0f;
        Entries[1, 1] = 1.0f;
        Entries[1, 2] = 0.0f;

        Entries[2, 0] = 0.0f;
        Entries[2, 1] = 0.0f;
        Entries[2, 2] = 1.0f;
    }

    public HMatrix2D(float[,] multiArray) 
    {
        if(multiArray.GetLength(0) == 3 && multiArray.GetLength(1) == 3) // Checks if multiArray has 3 rows & columns
        {
            for(int r = 0; r < 3; r++) 
            {
                for(int c = 0; c < 3; c++) 
                {
                    Entries[r,c] = multiArray[r,c];
                }
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
        float m10, float m11, float m12,
        float m20, float m21, float m22)
    {
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        Entries[1,0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    public void SetIdentity() // Resets the matrix to an identity matrix
    {
        for(int y = 0; y < 3; y++)
        {
            for(int x = 0; x < 3; x++)
            {
                Entries[x, y] = (x == y) ? 1.0f : 0.0f;
                /*if(x == y) 
                {
                    Entries[x, y] = 1.0f; // Sets the diagonal points to 1, because (0,0) (1,1) etc.
                }
                else 
                {
                    Entries[x, y] = 0.0f; // Everything  else is set to 0
                }*/
            }
        }
    }

    public void Print() // Prints out the matrix in console
    {
        string result = "";
        for(int r = 0; r < 3; r++)
        {
            for(int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D aResult = new HMatrix2D();
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                aResult.Entries[r, c] = left.Entries[r, c] + right.Entries[r, c];
            }
        }

        return aResult;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D mResult = new HMatrix2D();
        for(int r = 0; r < 3; r++)
        {
            for(int c = 0; c < 3; c++)
            {
                mResult.Entries[r, c] = left.Entries[r, c] - right.Entries[r, c];
            }
        }

        return mResult;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D sResult = new HMatrix2D();
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                sResult.Entries[r, c] = left.Entries[r, c] * scalar;
            }
        }

        return sResult;
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for(int r = 0; r < 3; r++)
        {
            for(int c = 0; c < 3; c++)
            {
                if (left.Entries[r, c] != right.Entries[r, c])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
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

    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
            (
            left.Entries[0,0] * right.x + left.Entries[0,1] * right.y + left.Entries[0,2] * right.h,
            left.Entries[1,0] * right.x + left.Entries[1,1] * right.y + left.Entries[1,2] * right.h
            );
    }

    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        {
            Entries = new float[3,3]
            {
                {
                    left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],
                    left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],
                    left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2]
                },
                {
                    left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
                    left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
                    left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2]
                },
                {
                    left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
                    left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
                    left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
                }
            }
        };
    }

    public void SetRotationMatrix(float rotDeg)
    {
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;

        Entries[0, 0] = Mathf.Cos(rad);
        Entries[0, 1] = -Mathf.Sin(rad);
        Entries[1, 0] = Mathf.Sin(rad);
        Entries[1, 1] = Mathf.Cos(rad);
    }

    public void SetTranslationMatrix(float transX, float transY)
    {
        SetIdentity();
        Entries[0, 2] = transX;
        Entries[1, 2] = transY;
    }
}