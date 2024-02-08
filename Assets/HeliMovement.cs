using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
 
public class HeliMovement : MonoBehaviour
{
    [SerializeField]
    GameObject DeathObject;
    //LJUD/MUSIK FILER
    [SerializeField] public AudioSource bakgrundsMusik;
    [SerializeField] public AudioSource helikopterLjud;
    [SerializeField] public AudioSource jump;
    [SerializeField] public AudioSource explosion;

    public int MenuScene;
    public int CutScene;

    Rigidbody2D myRigidBody2D;

    public static bool GameIsPaused = false;

    public bool IsDead = false;

    public GameObject DeathSceneUI;

    
    float quitTimer = 0;
    float quitTimer2 = 0;

    private bool dubblepoints = false;

    int hp = 1;

    

    GameStatus SM;
    Animator Explotion;
    // Start is called before the first frame update
    void Start()
    {
        helikopterLjud.Play();
        bakgrundsMusik.Play();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        SM = FindObjectOfType<GameStatus>();
        Explotion = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        //Används inte
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
            if (IsDead == false) 
            {
                jump.Play();
            }
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
        //Stänga av dubbel poäng power-up efter en stund
        if (quitTimer2 > 0)
        {
           dubblepoints = true; 
           quitTimer2 -= Time.deltaTime;

            


        }
       
        
        if (quitTimer2 <= 0)
        {
           

            dubblepoints = false;


        }
        //pausa hoppljud när man dör
        if (Time.timeScale == 0f)
        {
            jump.Stop();
        }
        //Om man hamnar av skärmen så dör man
        if(transform.position.y <= -10)
        {
            IsDead = true;
            Explotion.Play("explotion");
            explosion.Play();
            helikopterLjud.Stop();
            bakgrundsMusik.Stop();
            myRigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
            Invoke("GameOver", 0.5f);
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
            quitTimer2 = 10;
        }
        //Collect Food script
        GameObject otherGameObject1 = collision.gameObject;
        mat hitmat = otherGameObject1.GetComponent<mat>();
        if (hitmat != null)
        {
            hitmat.TakeDamage();
            GameStatus.instance.AddScore();

        }
        if (dubblepoints == true)
        {
            if (hitmat != null)
            {
                hitmat.TakeDamage();
                SM.Score += 1;

            }
            
        }
        if (dubblepoints == false)
        {
            if (hitmat != null)
            {
                hitmat.TakeDamage();
                SM.Score += 0;

            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Explotion.Play("explotion");
        explosion.Play();
        helikopterLjud.Stop();
        bakgrundsMusik.Stop();
        myRigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        Invoke("GameOver", 0.5f);
        


    }

    void GameOver()
    {
        DeathSceneUI.SetActive(true);
        Time.timeScale = 0f;
        IsDead = true;
    }
}   

