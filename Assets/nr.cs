using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class nr : MonoBehaviour
{
    [SerializeField]
    GameObject DeathObject;

    public int MenuScene;

    Rigidbody2D myRigidBody2D;

    public static bool GameIsPaused = false;

    public GameObject DeathSceneUI;

    float quitTimer = 0;
    float quitTimer2 = 0;

    private bool dubblepoints = false;

    int hp = 1;

    ScoreManager SM;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        SM = FindObjectOfType<ScoreManager>();

    }

    public void TakeDamage()
    {
         hp -= 1;
        if (hp == 0)
        {
            Destroy(gameObject);
            
        }
    }

   
       
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody2D.velocity = new Vector2(0, 10);

        }

        if (quitTimer > 0)
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





        if (quitTimer2 > 0)
        {
            quitTimer2 -= Time.deltaTime;

            dubblepoints = true;


        }




    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Power-UP #1 Halv i storlek
        GameObject otherGameObject = collision.gameObject;
        powerup hitpowerup = otherGameObject.GetComponent<powerup>();
        if (hitpowerup != null)
        {
            hitpowerup.TakeDamage();
            quitTimer = 5;
        }
       //Power-Up #2 Dubbel score
        GameObject otherGameObject2 = collision.gameObject;
        powerup2 hitpowerup2 = otherGameObject2.GetComponent<powerup2>();
        if (hitpowerup2 != null)
        {
            hitpowerup2.TakeDamage();
            quitTimer2 = 5;
        }
        
        GameObject otherGameObject1 = collision.gameObject;
        mat hitmat = otherGameObject1.GetComponent<mat>();
        if (hitmat != null)
        {
            hitmat.TakeDamage();
            SM.Score += 1;

        }
        if (dubblepoints == true)
        {
            if (hitmat != null)
            {
                hitmat.TakeDamage();
                SM.Score += 1;

            }

        }      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathSceneUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}

