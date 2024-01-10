using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nr : MonoBehaviour
{
    Rigidbody2D myRigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            myRigidBody2D.velocity = new Vector2(0, 10);
           // myRigidBody2D.AddForce(new Vector2(0, 20), ForceMode2D.);
        }
    }
}
