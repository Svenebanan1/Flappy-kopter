using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class nr : MonoBehaviour
{
    Rigidbody2D myRigidBody2D;

    float quitTimer = 0;

    bool powerupone = false;

    int Score = 0;

    [SerializeField]
    GameObject textgameObject;
    TextMeshProUGUI textComponent;

    string ScoreText;
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

        }

        if (quitTimer>0)
        {
            quitTimer -= Time.deltaTime;
            gameObject.transform.localScale = new Vector2(0.5f, 0.5f);

        }
        else
        {
            gameObject.transform.localScale = new Vector2(1, 1);
        }
    
        if (quitTimer == 0)
        {

            gameObject.transform.localScale = new Vector2(1, 1);
        }
        ScoreText = "Score: " + Score;
        textComponent.text = ScoreText;
                    //Vi kan göra en bool 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject otherGameObject = collision.gameObject;
        powerup hitpowerup = otherGameObject.GetComponent<powerup>();
        if (hitpowerup != null)
        {
            hitpowerup.TakeDamage();
            quitTimer = 5;
        }
        GameObject otherGameObject1 = collision.gameObject;
        mat hitmat = otherGameObject1.GetComponent<mat>();
        if (hitmat != null)
        {
            hitmat.TakeDamage();
            Score += 1;
           
        }
       
        
    }
   
}

