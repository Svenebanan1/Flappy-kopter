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
        transform.position += new Vector3(-5,0) * Time.deltaTime;

    }
}
