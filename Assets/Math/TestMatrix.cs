using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    // Start is called before the first frame update
    void Start()
    {
        //mat.setIdentity();
        //mat.Print();

        Question2();
    }

    public void Question2()
    {
        //Declare matrices and vector
        HMatrix2D mat1 = new HMatrix2D(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f);
        HMatrix2D mat2 = new HMatrix2D(9.0f, 8.0f, 7.0f, 6.0f, 5.0f, 4.0f, 3.0f, 2.0f, 1.0f);
        HMatrix2D resultMat;

        HVector2D vec1 = new HVector2D(1.0f, 2.0f);

        // Matrix and vector multiplication
        vec1 = mat1 * vec1;

        // Matrix multiplication
        resultMat = mat1 * mat2;

        //Debug.Log(vec1);
        //Debug.Log(resultMat);

        vec1.Print();
        resultMat.Print();
    }
}
