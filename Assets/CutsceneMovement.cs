using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneMovement : MonoBehaviour
{
    [SerializeField] public AudioSource kidsCheeringSound;

    Rigidbody2D CutSceneRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        CutSceneRigidBody = GetComponent<Rigidbody2D>();
        kidsCheeringSound.Play();
        Invoke("MoveHelicopter", 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveHelicopter()
    {
        CutSceneRigidBody.velocity = new Vector2(0.04f, 0);
    }
}
