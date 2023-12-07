using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat1 = new HMatrix2D(1, 2, 1, 0, 1, 0, 2, 3, 4);
    private HMatrix2D mat2 = new HMatrix2D(2, 5, 1, 6, 7, 1, 1, 8, 1);
    void Start()
    {
        mat1.setIdentity();
        mat1.Print();

        HMatrix2D matResult = mat1 * mat2;
        matResult.Print();
    }
}
