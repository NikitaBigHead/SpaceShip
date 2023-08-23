using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float speed;
    private float radius;
    [SerializeField] private float damage = 25f;
    private void Awake()
    {
        float minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
        radius = (maxX - minX) * 0.1f;
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector2(0,-speed));

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,radius);
        foreach(Collider2D col in colliders)
        {
            if(col.tag == "Player")
            {
                //damage player 
                Destroy(gameObject); break;
            }
            else if(col.tag == "Ground")
            {
                Destroy(gameObject); break;
            }
        }
    }

}
