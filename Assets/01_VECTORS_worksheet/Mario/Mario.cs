using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 10f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = (planet.position - transform.position);  //Calculates gravity vector

        moveDir = new Vector3(gravityDir.y, -gravityDir.x, 0f);  //Calculates move direction using perpendicular value of gravity
        moveDir = moveDir.normalized * -1f;  //Normalize move vector to get unit vector (direction)

        rb.AddForce(moveDir * force);  //Apply force to astronaut using moveDir unit vector multiplied by force scalar

        gravityNorm = gravityDir.normalized;  //Normalize gravity vector to get unit vector (direction)
        rb.AddForce(gravityNorm * gravityStrength);  //Apply gravity force to astronaut using gravityNorm unit vector multiplied by scalar gravity strength

        float angle = Vector3.SignedAngle(Vector3.right, moveDir, Vector3.forward);  //Calculates angle between x axis (Vector3.right) and move direction,
                                                                                     //along the perspective of the z axis

        rb.MoveRotation(Quaternion.Euler(0, 0, angle));  //Rotate the sprite along the z axis

        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red); //Gravity vector arrow
        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue); //Move Direction vector arrow
    }
}


