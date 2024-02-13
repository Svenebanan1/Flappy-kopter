using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static GameStatus instance;

    public int CollectedFood;
    public int MenuFood;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        MenuFood = PlayerPrefs.GetInt("CollectedFood", 0);
        MenuFood = PlayerPrefs.GetInt("MenuFood", 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", CollectedFood);
        PlayerPrefs.SetInt("MenuFood", MenuFood);
    }

    public void AddScore()
    {
        CollectedFood++;
        updateHighScore();
    }

    public void updateHighScore()
    {
        MenuFood+= 25;
    }


   

    public void ResetScore()
    {
        CollectedFood = 0;
    }
}
