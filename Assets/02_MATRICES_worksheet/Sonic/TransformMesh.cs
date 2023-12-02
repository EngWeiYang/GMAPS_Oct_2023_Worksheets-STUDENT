using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        Translate(1, 1);
    }


    void Translate(float x, float y)
    {
        //Set transformation matrix for translation
        transformMatrix.setIdentity();
        transformMatrix.setTranslationMat(x,y);

        Transform();  //Apply translation
        pos = transformMatrix * pos;  //Update position
    }
    /*
    void Rotate(float angle)
    {
        transformMatrix.setTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.setIdentity();

        transformMatrix.setRotationMat(angle);

        transformMatrix.setIdentity();
        transformMatrix = fromOriginMatrix * transformMatrix;

        Transform();
    }*/

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);  //Creates a new HVector2D using the vertex
            vert = transformMatrix * vert;  //Apply the transformation
            vertices[i].x = vert.x;  //Update vertex's x coordinate
            vertices[i].y = vert.y;  //Update vertex's y coordinate
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}