using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRampUpSpeed : Projectile
{
    public float acceleration = 0.01f;

    private void FixedUpdate()
    {
        Vector2 movement = direction * speed * Time.fixedDeltaTime;
        transform.position += new Vector3(movement.x, movement.y, 0);
        speed += acceleration;
    }
}
