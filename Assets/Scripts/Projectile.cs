using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 direction = Vector2.up;
    public float speed = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = direction * speed * Time.fixedDeltaTime;
        transform.position += new Vector3(movement.x, movement.y, 0);
    }
}
