using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    public int GameScene;
    public void RetryGame()
    {
        SceneManager.LoadScene(GameScene);
        Time.timeScale = 1f;
    }
}
