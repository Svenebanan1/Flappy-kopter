using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayButton : MonoBehaviour
{
    public int Score;
    public int gameStartScene;
    [SerializeField] public AudioSource lobbyMusic;
    public void Start()
    {
        //Spela LobbyMusic när man öppnar menyn
        lobbyMusic.Play();
    }
     void Update()
     {
            if (Input.GetKey(KeyCode.Return))
            {
                //Loads Game Scene
                SceneManager.LoadScene(gameStartScene);
            } 
     }

    
}
