using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsCaptain = true;
    public Player OtherPlayer;

    float Magnitude(Vector3 vector)
    {
        float magnitude = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
        return magnitude;
    }

    Vector3 Normalise(Vector3 vector)
    {
        float mag = Magnitude(vector);
        Vector3 vecNormalised = vector / mag;

        return vecNormalised;
    }

    //float Dot(Vector3 vectorA, Vector3 vectorB)
    //{
    //    // Your code here
    //}

    //float AngleToPlayer()
    //{
    //    // Steps to calculate the angle between the direction Captain is facing and 
    //    // the direction from Captain to Other
    //    // 1. A
    //    // 2. B
    //    // 3. Calculate the angle between the vectors from A and B
    //    //    3.1 Calculate the dot product between A and B
    //    //       3.1.1 Calculate the magnitude of the vector from Captain to Other (A)
    //    //       3.1.2 Normalise the vector from Captain to Other
    //    //       3.1.3 Calculate the dot product of the normalised vectors A and B
    //    //    3.2 From the dot product, calculate the actual angle between A and B
    //    //       3.2.1 Take the arc cosine (acos) of the dot product (because if 
    //    //             both vector are normalised, the dot product equals the cos
    //    //             of the angle between vectors A and B.
    //    //       3.2.2 The acos angle returned is in radians. We must convert to
    //    //             degrees.

    //    // A
    //    // Steps to draw the arrow that represents the vector from Captain to Other 
    //    // 1. Find the vector from Captain to Other
    //    //     1.1 Find the position of Captain (A -- from)
    //    //     1.2 Find the position of Other (B -- to)
    //    //     1.3 Calculate B-A to get the vector from A to B
    //    // 2. Draw the arrow to represent visually the vector AB
    //    //

    //    // Your code here

    //    // B
    //    // Steps to draw an arrow that represents which direction Captain is facing
    //    // 1. Find which vector to draw as an arrow
    //    //    1.1 The transform.forward vector of Captain
    //    // 2. Draw the arrow to represent visually the the transform.forward vector of Captain
    //    DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);

    //    // CALCULATING THE ANGLE

    //    // Your code here
    //    // ...

    //    // Your code here
    //}

    void Update()
    {
        if (IsCaptain)
        {
            Vector3 CaptainToPlayer1 = (transform.position - OtherPlayer.transform.position) * -1f;  //Captain to player 1 vector calculation
            DebugExtension.DebugArrow(transform.position, Normalise(CaptainToPlayer1), Color.black);  //Black arrow from captain to player

            DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);  //Blue arrow to show captain's forward vector (facing direction)

            float angle = Vector3.SignedAngle(transform.forward, CaptainToPlayer1, Vector3.up);
            //Debug.Log(angle);
        }
    }
}
