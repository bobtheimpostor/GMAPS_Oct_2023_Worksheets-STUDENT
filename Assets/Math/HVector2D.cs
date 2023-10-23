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
        float mag = (float)Math.Sqrt(x * x + y * y);
        return mag;
    }

    public void Normalize()
    {
        float mag = Magnitude();
        x /= mag;
        y /= mag;
    }

    // public float DotProduct(/*???*/)
    // {

    // }

    // public HVector2D Projection(/*???*/)
    // {

    // }

    // public float FindAngle(/*???*/)
    // {

    // }

    public Vector2 ToUnityVector2()
    {
        return Vector2.zero; // change this
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y, 0); // change this
    }

    // public void Print()
    // {

    // }
}
