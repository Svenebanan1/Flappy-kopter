using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousesMovement : MonoBehaviour
{
    Rigidbody2D MyRigidBody;

    
    // Start is called before the first frame update
    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //F�r husen att r�ra sig lite
        MyRigidBody.velocity = new Vector2(-3, 0);
    }
}
