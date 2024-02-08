using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneMovement : MonoBehaviour
{

    [SerializeField] public AudioSource kidsCheeringSound;

    Rigidbody2D CutSceneRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        CutSceneRigidBody = GetComponent<Rigidbody2D>();
        kidsCheeringSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        Invoke("MoveHelicopter", 1.25f);
    }

    void MoveHelicopter()
    {
        CutSceneRigidBody.velocity = new Vector2(0.04f, 0);
        
    }
}
