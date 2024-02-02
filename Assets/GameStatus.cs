using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static GameStatus instance;

    public int Score;
    public int HighScore;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("Score", 0);
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("HighScore", HighScore);
    }

    public void AddScore()
    {
        Score++;
        updateHighScore();
    }

    public void updateHighScore()
    {
        HighScore++;
    }

    public void ResetScore()
    {
        Score = 0;
    }
}
