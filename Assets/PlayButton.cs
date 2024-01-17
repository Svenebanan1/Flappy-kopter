using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   
    public int gameStartScene;
    [SerializeField] public AudioSource lobbyMusic;

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }

    public void Start()
    {
        lobbyMusic.Play();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(gameStartScene);
        }
    }
}
