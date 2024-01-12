using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;


   
    public TMP_Text scoreText;

     public int Score = 0;
   

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Update()
    {
        scoreText.text = Score.ToString() + " Points ";
    }

    // Update is called once per frame
   
}
