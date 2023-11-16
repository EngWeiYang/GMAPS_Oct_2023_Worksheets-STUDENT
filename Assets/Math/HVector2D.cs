using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    public static HVector2D operator +(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x + b.x, a.y + b.y);
    }

    public static HVector2D operator -(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x - b.x, a.y - b.y);
    }

    public static HVector2D operator *(HVector2D a, float scalar)
    {
        return new HVector2D(a.x * scalar, a.y * scalar);
    }

    public static HVector2D operator /(HVector2D a, float scalar)
    {
        return new HVector2D(a.x / scalar, a.y / scalar);
    }

    public float Magnitude()
    {
        return Mathf.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        float mag = Magnitude();

        x /= mag;
        y /= mag;
    }

    public float DotProduct(HVector2D vec)
    {
        return x * vec.x + y * vec.y;
    }

    public HVector2D Projection(HVector2D b)
    {
        HVector2D proj = b * (DotProduct(b) / b.DotProduct(b)); //DotProduct(b) calculates dot product of c and b
                                                                //b.DotProduct(b) calculates the magnitude squared of vector b
                                                                //The division of these two gives the scalar of the projected vector
                                                                //and by multiplying the scalar by vector b gives the projected vector

        return proj;
    }

    // public float FindAngle(/*???*/)
    // {

    // }

    public Vector2 ToUnityVector2()
    {
        return new Vector2(x, y);
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y);
    }

    // public void Print()
    // {

    // }
}
