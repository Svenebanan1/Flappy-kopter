using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
     public int gameStartScene;
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();

    }

    public void StartGame()
    {
        // Script för att Play knappen ska Starta spelet
        SceneManager.LoadScene(gameStartScene);
    }
}
