using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Jump()
    {
        //Rearranging equations, we get...
        //v*v = u*u + 2as;
        //u*u = v*v - 2as;
        //u = sqrt(v*v - 2as);

        //When v = 0 (at the highest point),
        //u = sqrt(-2as), where a = Physics.gravity and s = Height

        float u = Mathf.Sqrt(-2 * Physics.gravity.y * Height);  //Calculate u
        rb.velocity = new Vector3(0, u, 0);  //Apply u to rigidbody's upward velocity vector
    }

    private void Update()
    {
        //Apply Jump() if spacebar is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}