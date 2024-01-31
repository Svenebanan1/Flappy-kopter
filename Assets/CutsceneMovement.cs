using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneMovement : MonoBehaviour
{

    [SerializeField] public AudioSource kidsCheeringSound;

    Rigidbody2D CutScene;
    // Start is called before the first frame update
    void Start()
    {
        CutScene = GetComponent<Rigidbody2D>();
        kidsCheeringSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        CutScene.velocity = new Vector2(2, 0);
    }
}
