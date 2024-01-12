using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D myRigidBody2D;
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        myRigidBody2D.velocity = new Vector2(-5, 0);
    }
}
