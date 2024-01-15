using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Parent : MonoBehaviour
{
    Rigidbody2D myRigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, Random.Range(-4, 4));
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        myRigidBody2D.velocity = new Vector2(-5, 0);
    }
}
