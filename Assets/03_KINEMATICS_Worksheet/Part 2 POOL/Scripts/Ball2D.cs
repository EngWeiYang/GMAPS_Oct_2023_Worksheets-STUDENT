using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector] public float Radius;

    private void Start()
    {
        //Set position values to object's starting position
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        //Calculate sprite's radius
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }
    
    public bool IsCollidingWith(float x, float y)  //Check collision with mouse
    {
        float distance = Util.FindDistance(Position, new HVector2D(x,y));
        return distance <= Radius;
    }
    
    public bool IsCollidingWith(Ball2D other)  //Check collision with other balls
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }
    
    private void UpdateBall2DPhysics(float deltaTime)
    {
        //Calculate displacement using velocity formula
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        //Calculate new position based on displacement (negative to go in opposite direction of pool cue drag)
        Position.x -= displacementX;
        Position.y -= displacementY;

        transform.position = new Vector2(Position.x, Position.y);  //Apply displacement to transform position
    }
}