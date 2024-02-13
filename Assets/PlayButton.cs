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
                //Reference to ResetScore() void
                ResetScore();
            }
        

        
     }
    //Ställer om Score i spel scenen
    public void ResetScore()
    {
        Score = 0;
    }
    public void StartGame()
        {
            // Script för att Play knappen ska Starta spelet
            SceneManager.LoadScene(gameStartScene);
        }
    
}
