using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMovement : MonoBehaviour
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
        //G�r s� att himlen bakom husen r�r sig lite grann
        MyRigidBody.velocity = new Vector2(-2, 0);
    }
}
