using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    Vector2 min;
    Vector2 max;
    bool isLeftDir = true;
    public float speed = 0.3f;
    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isLeftDir == true )
        {
            if(transform.position.x <= min.x)
            {
                isLeftDir = false;
            }
            transform.Translate(new Vector2(-speed,0));
        }
        else
        {
            if( transform.position.x >= max.x)
            {
                isLeftDir = true;
            }
            transform.Translate(new Vector2(speed, 0));
        }
    }
}
