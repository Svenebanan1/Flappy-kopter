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
    public GameObject OptionsMenuUI;

    [SerializeField]
    GameObject Tower;

    [SerializeField]
    GameObject DeathBarrier;
    
    public GameObject DeathSceneUI;
    public GameObject pauseMenuUI;

    //LJUD/MUSIK FILER
    [SerializeField] public AudioSource BackgroundMusic;
    [SerializeField] public AudioSource HelikopterAudio;
    [SerializeField] public AudioSource JumpAudio;
    [SerializeField] public AudioSource ExplosionAudio;

    public int MenuScene;
    public int CutScene;
    
    Rigidbody2D myRigidBody2D;

    public static bool GameIsPaused = false;

    public bool IsDead = false;

    private bool dubblepoints = false;
    
    float quitTimer = 0;
    float quitTimer2 = 0;

    int hp = 1;

    

    GameStatus SM;
    Animator ExplotionAnimation;
    // Start is called before the first frame update
    void Start()
    {
        HelikopterAudio.Play();
        BackgroundMusic.Play();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        SM = FindObjectOfType<GameStatus>();
        ExplotionAnimation = GetComponent<Animator>();
    }
        
    //ANVÄNDS ALDRIG
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
        if (IsDead == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                    OptionsResume();
                }
                else
                {
                    Pause();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsDead == false) 
            {
                JumpAudio.Play();
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
        //Stänga av dubbel poäng power-up efter 10 sekunder
        if (quitTimer2 > 0)
        {
           dubblepoints = true; 
           quitTimer2 -= Time.deltaTime;
        }
       
        
        if (quitTimer2 <= 0)
        {
            dubblepoints = false;
        }
        
        if(IsDead == true)
        {
            Invoke("GameOver", 0.55f);
            myRigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
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
                SM.CollectedFood += 1;

            }
            
        }
        if (dubblepoints == false)
        {
            if (hitmat != null)
            {
                hitmat.TakeDamage();
                SM.CollectedFood += 0;

            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        pauseMenuUI.SetActive(false);
        JumpAudio.Stop();
        ExplosionAudio.Play();
        ExplotionAnimation.Play("explotion");
        IsDead = true;

    }

    void GameOver()
    {   
        HelikopterAudio.Stop();
        BackgroundMusic.Stop();
        DeathSceneUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void OptionsResume()
    {
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MenuScene);
    }


    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}   

