using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat  = new HMatrix2D();
    void Start()
    {
        mat.setIdentity();
        mat.Print();
    }
}
