using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);  
        moveDir = new HVector2D(-gravityDir.y, gravityDir.x);

        gravityNorm = new HVector2D(gravityDir.x/ gravityDir.Magnitude(), gravityDir.y / gravityDir.Magnitude());
        moveDir = new HVector2D(moveDir.x/ moveDir.Magnitude(), moveDir.y/ moveDir.Magnitude());

        rb.AddForce(gravityNorm.ToUnityVector2() * gravityStrength);
        rb.AddForce(moveDir.ToUnityVector2() * force);



        DebugExtension.DebugArrow(transform.position, gravityDir.ToUnityVector3(), Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir.ToUnityVector3(), Color.blue);

        //DebugExtension.DebugArrow(transform.position, gravityNorm.ToUnityVector3(), Color.yellow);
    }
}
