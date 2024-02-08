using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject DeathObject;

    public static bool GameIsPaused = false;

    public static bool IsDead = false;

    public GameObject pauseMenuUI;

    public GameObject OptionsMenuUI;

    public GameObject DeathSceneUI;

    public int MenuScene;
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
        
        if(IsDead == true)
        {
            GameOver();
        }

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
        if (IsDead == false)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
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
    void GameOver()
    {
        DeathSceneUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
