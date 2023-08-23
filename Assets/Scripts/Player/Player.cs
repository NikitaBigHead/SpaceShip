using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;

    public float speed = 1.5f;

    [SerializeField]
    private GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FireMissile()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(joystick.horizontal, joystick.vertical, 0) * speed * Time.fixedDeltaTime;
    }
}
