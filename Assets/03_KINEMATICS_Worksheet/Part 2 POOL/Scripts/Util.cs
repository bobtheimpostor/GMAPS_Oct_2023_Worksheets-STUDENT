using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        return Mathf.Sqrt(p1.Magnitude() * p1.Magnitude() + p2.Magnitude() * p2.Magnitude());
    }
}

