using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Parent : MonoBehaviour
{

    [SerializeField]
    private float Bound;
    private void Update()
    {
        if (transform.position.x < Bound)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    { 
        //myRigidBody2D.velocity = new Vector2(-5, 0);
        transform.position += new Vector3(-5,0) * Time.deltaTime;

    }
}
