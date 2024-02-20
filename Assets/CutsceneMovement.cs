using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneMovement : MonoBehaviour
{
    public GameObject CutSceneAnimation;
    public GameObject CutSceneChildren;
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
        Invoke("Continue", 3.15f);
    }

    void MoveHelicopter()
    {
        CutSceneRigidBody.velocity = new Vector2(0.04f, 0);
        
    }

    void Continue()
    {
        CutSceneAnimation.SetActive(false);
        CutSceneChildren.SetActive(true);
    }
}
