using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;

        HVector2D a = new HVector2D(8f, 5f);
        HVector2D b = new HVector2D(1f, 3f);
        float distance = Util.FindDistance(a, b);
        Debug.Log(distance);  
    }

    public bool IsCollidingWith(float x, float y)
    {
        float distance = new HVector2D(x - Position.x, y - Position.y).Magnitude();
        Debug.Log(distance);
        Debug.Log(Radius);
        return distance <= Radius;
    }

    public bool IsCollidingWith(Ball2D other)
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
        float displacementX = Velocity.x;
        float displacementY = Velocity.y;

        Position.x += displacementX;
        Position.y += displacementY;

        transform.position = new Vector2(Position.x, Position.y);
    }
}

